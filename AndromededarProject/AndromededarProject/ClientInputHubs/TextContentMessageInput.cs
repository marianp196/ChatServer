using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.Services.ContentMessageServices;
using Andromedarproject.Users.Abstractions;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ClientInputHubs
{
    public class TextContentMessageInput : Hub
    {
        public TextContentMessageInput(IContentRouter<TextContent> router)
        {
            _router = router;
        }

        public async Task SendTextMessage(string user, BasicInputMessage<TextContent> message)
        {
            _router.Rout(message.Sender, message.Target, message.Content);
        }


        private IContentRouter<TextContent> _router;        
    }
}
