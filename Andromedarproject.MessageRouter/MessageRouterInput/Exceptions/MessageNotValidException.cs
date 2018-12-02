using System;

namespace Andromedarproject.MessageRouter.MessageRouterInput.Exceptions
{
    public class MessageNotValidException : Exception
    {
        public MessageNotValidException(string message) : base(message)
        {

        }
    }
}
