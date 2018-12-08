using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.AdressValidator.Exceptions
{
    public class SenderNotValidException : Exception
    {
        public SenderNotValidException(string message) : base(message)
        {
        }
    }
}
