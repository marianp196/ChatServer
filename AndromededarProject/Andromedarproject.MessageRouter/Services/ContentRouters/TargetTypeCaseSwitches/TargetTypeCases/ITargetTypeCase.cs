using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentRouters.TargetTypeCaseSwitches.TargetTypeCases
{
    public interface ITargetTypeCase<TContent>
    {
        bool IsResponsible(EAdressType messageType);
        IEnumerable<BasicOutputMessage<TContent>> GetOutputs(Adress sender, Adress target, TContent content);
    }
}
