using System;
using System.Collections.Generic;
using System.Text;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.MessageRouterInput.InputCases;

namespace Andromedarproject.MessageRouter.MessageRouterInput
{
    public class InputCaseSwitch : IRouterInput
    {

        public InputCaseSwitch(IEnumerable<IInputCase> inputCases)
        {
            _inputCases = inputCases ?? throw new ArgumentNullException(nameof(inputCases));
        }

        public InputCaseSwitch(IRouterInput routerInput, IEnumerable<IInputCase> inputCases)
        {
            _routerInput = routerInput ?? throw new ArgumentNullException(nameof(routerInput));
            _inputCases = inputCases ?? throw new ArgumentNullException(nameof(inputCases));
        }

        public void Rout(BasicInputMessage basicInputMessage)
        {
            IInputCase inputCase = getInputCaseOrNull(basicInputMessage);

            if (inputCase == null)
                throw new Exception("MessageType can not be handled");

            if (_routerInput != null)
                _routerInput.Rout(basicInputMessage);
        }

        private IInputCase getInputCaseOrNull(BasicInputMessage basicInputMessage)
        {
            foreach(var inputCase in _inputCases)
                if (inputCase.IsResponsible(basicInputMessage))
                    return inputCase;
            return null;
        }

        private readonly IRouterInput _routerInput;
        private readonly IEnumerable<IInputCase> _inputCases;
    }
}
