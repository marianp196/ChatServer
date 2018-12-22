using Andromedarproject.MessageDto.Adresses;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromedarproject.Output.NetworkAccess;

namespace Andromedarproject.MessageRouter.BasicMessagePipe.TextContentMessage.OutputGenerators
{
    public interface IOutputGenerator<TContent>
    {
        bool IsResponsible(EAdressType targetAdressType);
        Task<IEnumerable<OutputDto<TContent>>> GetOutputs(Message<TContent> inputMessage);
    }
}
