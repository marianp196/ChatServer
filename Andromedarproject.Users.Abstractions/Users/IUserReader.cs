using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.Users.Abstractions
{
    public interface IUserReader
    {
        bool TryGetByName(string name, out User user);
        bool PasswordValid(User user, string input);
    }
}
