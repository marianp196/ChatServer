using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.BasicMessagePipe;
using AndromededarProject.Web.Authetication;
using AndromededarProject.Web.ConnectionPool;
using ChatserverProtokoll.Input;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ClientInputHubs
{
    public abstract class ChatHub : Hub
    {
        public ChatHub(IContentRouter<TextContent> router, IConnectionPool connectionPool)
        {
            _router = router;
            _connectionPool = connectionPool;
        }

        
        public virtual async Task SendTextMessage(string user, BasicInputMessage<TextContent> message)
        {
            var messageDto = message.ConvertToMessage();
            try
            {
                await _router.Rout(new UserDto { Name = "User" },  messageDto);
            }
            catch (NotValidException e)
            {
                if (e.MessageViolations == null)
                {
                    await sendResponse(new MessageResult
                    {
                        ClientID = message.Id,
                        State = EState.Error,
                        Errors = 
                        new Error[] {new Error { Code = "unkn", Message = e.Message} }
                        
                    });
                    return;
                }

                var errors = e.MessageViolations.Select(x => new Error { Code = x.Code, Message = x.Text });
                await sendResponse(new MessageResult
                {
                    ClientID = message.Id,
                    State = EState.Error,
                    Errors = errors
                });
                return;
            }
            catch (Exception e)
            {
                await sendResponse(new MessageResult
                {
                    ClientID = message.Id,
                    State = EState.Error,
                    Errors =
                        new Error[] { new Error { Code = "unkn", Message = e.Message } }

                });
                return;
            }

            
        }

        public override async Task OnConnectedAsync()
        {
            //Hier müsste dann noch das initialize ausgeführt werden.
            await base.OnConnectedAsync();
            _connectionPool.Add("User", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            _connectionPool.Remove("User");
        }

        private async Task sendResponse(MessageResult obj)
        {
            Clients.Caller.SendCoreAsync("MessageResult", new object[] { obj });
        }


        private readonly IContentRouter<TextContent> _router;
        private readonly IConnectionPool _connectionPool;
    }
}
