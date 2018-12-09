using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.AdressValidator.Exceptions
{
    public class AdressNotValidException : Exception
    {
        public AdressNotValidException(string message) : base(message)
        {
        }
    }
}
