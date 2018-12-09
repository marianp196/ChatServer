using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageRouter.Services.ContentRouters;
using Andromedarproject.Users.Abstractions;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ClientInputHubs
{
    public class TextContentMessageInput : Hub
    {
        public TextContentMessageInput(IUserReader provider)
        {
           // _router = provider.
        }

        public async Task SendTextMessage(string user, /*BasicInputMessage<TextContent>*/ string message)
        {
            //_router.Rout(message.Sender, message.Target, message.Content);
            Console.WriteLine(message);
        }


        private IContentRouter<TextContent> _router;        
    }
}
