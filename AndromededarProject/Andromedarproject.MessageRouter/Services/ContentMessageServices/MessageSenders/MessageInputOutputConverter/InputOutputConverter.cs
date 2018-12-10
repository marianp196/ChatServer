using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.MessageInputOutputConverter
{
    public class InputOutputConverter<TContent> : IInputOutputConverter<TContent>
    {
        public BasicOutputMessage<TContent> Convert(Adress sender, Adress targetUser, Adress group, TContent content)
        {
            var result = new BasicOutputMessage<TContent>();

            result.Sender = sender;
            result.SenderGroup = group;
            result.Target = targetUser;

            result.Content = content;

            return result.DeepCopy();
        }

        public BasicOutputMessage<TContent> Convert(Adress sender, Adress targetUser, TContent content)
        {
            return Convert(sender, targetUser, null, content);
        }
    }
}
