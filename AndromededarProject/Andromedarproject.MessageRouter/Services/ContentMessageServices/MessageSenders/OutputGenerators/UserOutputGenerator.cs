using System;
using System.Collections.Generic;
using System.Text;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.MessageInputOutputConverter;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators
{
    public class UserOutputGenerator<TContent> : OutputGenerator<TContent>
    {
        public UserOutputGenerator(IInputOutputConverter<TContent> converter) : base(converter)
        {
        }

        public override IEnumerable<BasicOutputMessage<TContent>> GetOutputs(Adress sender, Adress target, TContent content)
        {
            if (!IsResponsible(target.AdressType))
                throw new Exception("Not Rootable for this case");

            return new List<BasicOutputMessage<TContent>>() { Convert(sender, target, null, content) };
        }

        public override bool IsResponsible(EAdressType messageType)
        {
            return messageType == EAdressType.User;
        }
    }
}
