using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.Services.ContentRouters;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ClientInputHubs
{
    public class TextContentMessageInput : Hub
    {
        public TextContentMessageInput(/*IContentRouter<TextContent> router*/)
        {
            //_router = router ?? throw new ArgumentNullException(nameof(router));
        }

        public async Task InputTextContentMessage(string user, /*BasicInputMessage<TextContent>*/ string message)
        {
            //_router.Rout(message.Sender, message.Target, message.Content);
            Console.WriteLine(message);
        }


        private IContentRouter<TextContent> _router;        
    }
}
