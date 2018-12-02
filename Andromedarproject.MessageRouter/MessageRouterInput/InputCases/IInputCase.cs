using Andromedarproject.MessageDto.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.MessageRouterInput.InputCases
{
    public interface IInputCase : IRouterInput
    {
        bool IsResponsible(BasicInputMessage message);   
    }
}
