using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.MessageRouterInput.Users
{
    public interface IUserReader
    {
        bool TryGetByName(string name, out User user);
        bool PasswordValid(User user, string input);
    }
}
