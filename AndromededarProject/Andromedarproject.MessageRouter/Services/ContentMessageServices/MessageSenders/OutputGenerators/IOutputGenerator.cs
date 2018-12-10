using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators
{
    public interface IOutputGenerator<TContent>
    {
        bool IsResponsible(EAdressType targetAdressType);
        Task<IEnumerable<BasicOutputMessage<TContent>>> GetOutputs(Adress sender, Adress target, TContent content);
    }
}
