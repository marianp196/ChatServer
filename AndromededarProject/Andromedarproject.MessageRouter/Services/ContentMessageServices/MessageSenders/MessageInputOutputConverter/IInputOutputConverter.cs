using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.MessageInputOutputConverter
{
    public interface IInputOutputConverter<TContent>
    {
        BasicOutputMessage<TContent> Convert(Adress sender, Adress targetUser, Adress group, TContent content);
        BasicOutputMessage<TContent> Convert(Adress sender, Adress targetUser, TContent content);
    }
}
