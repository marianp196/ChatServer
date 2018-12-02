using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.MessageRouterOutput;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.MessageRouterInput.InputCases
{
    public abstract class BasicInputCase : IInputCase
    {
        public BasicInputCase(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        protected void Send(BasicOutputMessage message)
        {
            _output.Send(message);
        }

        public abstract bool IsResponsible(BasicInputMessage message);
        public abstract void Rout(BasicInputMessage basicInputMessage);

        private IOutput _output;        
    }
}
