using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.BasicMessagePipe;
using AndromededarProject.Web.Authetication;
using AndromededarProject.Web.ConnectionPool;
using ChatserverProtokoll.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ClientInputHubs
{
	[Authorize]
    public class ChatHub : Hub
    {
        public ChatHub(IContentRouter<TextContent> router, IConnectionPoolWriter<string> connectionPool)
        {
            _router = router;
            _connectionPool = connectionPool;
        }


        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await _connectionPool.Push("User", Context.ConnectionId);
            //Hier müsste dann noch das initialize ausgeführt werden. abholen liegengebliebener Nachrichten
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            _connectionPool.Remove("User");
        }

        public virtual async Task SendTextMessage(string user, BasicInputMessage<TextContent> message)
        {
            var messageDto = message.ConvertToMessage();
			var username = Context.User.Identity.Name;
			

            try
            {
                await _router.Rout(new UserDto { Name = username }, messageDto);
            }
            catch (NotValidException e)
            {
                if (e.MessageViolations == null)
                {
                    await unknownExceptionHandling(message, e);
                    return;
                }

                await notValidExceptionHandling(message, e);
                return;
            }
            catch (Exception e)
            {
                await unknownExceptionHandling(message, e);
                return;
            }

            await successHandling(messageDto);
        }

        private async Task successHandling(Message<TextContent> messageDto)
        {
            await sendResponse(new MessageResult
            {
                ClientID = messageDto.ClientMessageId,
                ServerID = messageDto.ServerId,
                State = EState.Success
            });
        }

        private async Task notValidExceptionHandling(BasicInputMessage<TextContent> message, NotValidException e)
        {
            var errors = e.MessageViolations.Select(x => new Error { Code = x.Code, Message = x.Text });
            await sendResponse(new MessageResult
            {
                ClientID = message.Id,
                State = EState.Error,
                Errors = errors
            });
        }

        private async Task unknownExceptionHandling(BasicInputMessage<TextContent> message, Exception e)
        {
            await sendResponse(new MessageResult
            {
                ClientID = message.Id,
                State = EState.Error,
                Errors = new Error[] { new Error { Code = "unknow", Message = e.Message } }

            });
        }

        private async Task sendResponse(MessageResult obj)
        {
            Clients.Caller.SendCoreAsync("MessageResult", new object[] { obj });
        }


        private readonly IContentRouter<TextContent> _router;
        private readonly IConnectionPoolWriter<string> _connectionPool;
    }
}
