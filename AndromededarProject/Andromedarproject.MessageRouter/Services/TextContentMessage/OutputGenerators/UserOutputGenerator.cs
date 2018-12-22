using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.utils;
using Andromedarproject.Output.NetworkAccess;

namespace Andromedarproject.MessageRouter.BasicMessagePipe.TextContentMessage.OutputGenerators
{
    public class UserOutputGenerator<TContent> : OutputGenerator<TContent>
    {

        public override async Task<IEnumerable<OutputDto<TContent>>> GetOutputs(Message<TContent> input)
        {
            if (!IsResponsible(input.Traget.AdressType))
                throw new Exception("Not Rootable for this case");

            var output = Convert(input);
            output.SenderType = ESenderType.User;
            output.Traget = input.Traget;
            return new List<OutputDto<TContent>>() { output.DeepCopy() };
        }

        public override bool IsResponsible(EAdressType messageType)
        {
            return messageType == EAdressType.User;
        }
    }
}
