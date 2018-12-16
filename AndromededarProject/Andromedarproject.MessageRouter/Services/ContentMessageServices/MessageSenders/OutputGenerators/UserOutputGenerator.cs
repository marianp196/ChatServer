using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.MessageRouter.Services.OutputServices;
using Andromedarproject.MessageRouter.utils;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators
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
