using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.MessageRouterInput.Exceptions;
using System;

namespace Andromedarproject.MessageRouter.MessageRouterInput
{
    public class MessageValidator : IRouterInput
    {
        public MessageValidator(IRouterInput routerInput)
        {
            _routerInput = routerInput ?? throw new ArgumentNullException(nameof(routerInput));
        }

        public void Rout(BasicInputMessage basicInputMessage)
        {
            checkAndThrowException(basicInputMessage);

            _routerInput.Rout(basicInputMessage);
        }

        private static void checkAndThrowException(BasicInputMessage basicInputMessage)
        {
            if (basicInputMessage == null)
                throw new ArgumentNullException(nameof(basicInputMessage));

            if (!basicInputMessage.isValid())
                throw new MessageNotValidException("Does not fit to Protocoll");

            if (basicInputMessage.MessageType == EMessageTypes.Message)
                if (basicInputMessage.Target == null || !basicInputMessage.Target.isValid())
                    throw new MessageNotValidException("Target-Adress not set");
        }

        private readonly IRouterInput _routerInput;
    }
}
