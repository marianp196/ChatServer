using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.AdressValidator.Exceptions
{
    public class TargetNotValidException : Exception
    {
        public TargetNotValidException(string message) : base(message)
        {
        }
    }
}
