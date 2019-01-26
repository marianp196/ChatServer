using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.BasicMessagePipe;
using AndromededarProject.Web.ClientInputHubs;
using AndromededarProject.Web.ConnectionPool;
using ChatserverProtokoll.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndromededarProject.Web.TextMessageInput
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextMessageInputController : ControllerBase
    {
		public TextMessageInputController(IContentRouter<TextContent> router, IConnectionPoolReader<string> connectionPoolReader)
		{
			_router = router;
			_connectionPoolReader = connectionPoolReader;
		}

		[Authorize]
		[HttpPost]
		public async Task<MessageResult> Post(BasicInputMessage<TextContent> input)
		{
			var userName = User.Identity.Name;
			var senderAdress = input.Sender;

			if (senderAdress == null)
				BadRequest(new MessageResult() { ClientID = input.Id, State = EState.Error});//genuare info

			if(! clientIsConnected(senderAdress))
				BadRequest(new MessageResult() { ClientID = input.Id, State = EState.Error });//genuaere info

			var routerInput = input.ConvertToMessage();
			try
			{
				await _router.Rout(new UserDto { Name = userName }, routerInput);
			}
			catch(NotValidException e)
			{
				BadRequest(createError(input, e));
			}

			return new MessageResult() { ServerID = routerInput.ServerId, State = EState.Success };
		}

		private bool clientIsConnected(Adress sender)
		{
			return _connectionPoolReader.TryRead(sender, out var x);
		}

		private MessageResult createError(BasicInputMessage<TextContent> message, NotValidException e)
		{
			var errors = e.MessageViolations.Select(x => new Error { Code = x.Code, Message = x.Text });
			return new MessageResult
			{
				ClientID = message.Id,
				State = EState.Error,
				Errors = errors
			};
		}

		private IContentRouter<TextContent> _router;
		private IConnectionPoolReader<string> _connectionPoolReader;
	}
}