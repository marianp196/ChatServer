using System;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageDto.Input.TextMessages;
using Andromedarproject.MessageRouter.MessageRouterOutput;

namespace Andromedarproject.MessageRouter.MessageRouterInput.InputCases
{
    public class UserTextMessageCase : BasicInputCase
    {
        public UserTextMessageCase(IOutput output) : base(output)
        {}

        public override bool IsResponsible(BasicInputMessage message)
        {
            return message.MessageType == EMessageTypes.Message && 
                            message.Target.AdressType == EAdressType.User;
        }

        public override void Rout(BasicInputMessage basicInputMessage)
        {
            if (basicInputMessage.MessageType != EMessageTypes.Message)
                throw new Exception("Message from false Type");
           

          
            throw new NotImplementedException();
        }
    }
}
