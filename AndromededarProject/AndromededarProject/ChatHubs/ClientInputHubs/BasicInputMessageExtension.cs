using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.BasicMessagePipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ClientInputHubs
{
    public static class BasicInputMessageExtension
    {
        public static Message<TContent> ConvertToMessage<TContent>(this BasicInputMessage<TContent> message)
        {
            var messageDto = new Message<TContent>();

            //testadten
            messageDto.ClientMessageId = Guid.NewGuid();
            messageDto.ClientTimestamp = DateTime.UtcNow;

            messageDto.Sender = message.Sender;
            messageDto.Traget = message.Target;
            messageDto.Content = message.Content;

            return messageDto;
        }
    }
}
