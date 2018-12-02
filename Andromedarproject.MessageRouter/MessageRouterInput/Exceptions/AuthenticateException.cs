using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.MessageRouterInput.Exceptions
{
    public class AuthenticateException : Exception
    {
        public AuthenticateException(string message) : base(message)
        {
        }
    }

    public class UserNotExistsException : AuthenticateException
    {
        public UserNotExistsException(string message) : base(message)
        {
        }
    }

    public class PasswordNotValidException : AuthenticateException
    {
        public PasswordNotValidException(string message) : base(message)
        {
        }
    }
}
