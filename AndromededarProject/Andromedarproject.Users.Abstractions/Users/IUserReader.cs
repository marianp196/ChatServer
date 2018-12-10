using Andromedarproject.Users.Abstractions.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.Users.Abstractions
{
    public interface IUserReader
    {
        Task<Result<User>> TryGetByName(string name);
        bool PasswordValid(User user, string input);
    }
}
