using System;
using System.Collections.Generic;
using System.Text;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;

namespace Andromedarproject.MessageRouter.Services.ContentRouters.TargetTypeCaseSwitches.TargetTypeCases
{
    public abstract class TragetTypeCase<TContent> : ITargetTypeCase<TContent>
    {      

        public TragetTypeCase(IInputOutputConverter<TContent> converter)
        {
            _converter = converter;
        }

        public abstract IEnumerable<BasicOutputMessage<TContent>> GetOutputs(Adress sender, Adress target, TContent content);
        public abstract bool IsResponsible(EAdressType messageType);

        protected BasicOutputMessage<TContent> Convert(Adress sender, Adress target, Adress group ,TContent content)
        {
            return _converter.Convert(sender, target,group, content);
        }

        private readonly IInputOutputConverter<TContent> _converter;
    }
}
