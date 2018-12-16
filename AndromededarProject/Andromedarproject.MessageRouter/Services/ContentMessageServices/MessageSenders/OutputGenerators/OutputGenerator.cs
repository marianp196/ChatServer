using System.Collections.Generic;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.MessageRouter.Services.OutputServices;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators
{
    public abstract class OutputGenerator<TContent> : IOutputGenerator<TContent>
    {     
        public abstract Task<IEnumerable<OutputDto<TContent>>> GetOutputs(Message<TContent> input);
        public abstract bool IsResponsible(EAdressType messageType);

        protected OutputDto<TContent> Convert(Message<TContent> input)
        {
            return new OutputDto<TContent>
            {
                Id = input.ServerId,
                ClientTime = input.ClientTimestamp.Value,
                UserSender = input.Sender,
                Content = input.Content
            };
        }
        
    }
}
