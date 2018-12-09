using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.Users.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.UserGroups.Moq
{
    public class UserServiceMoq : IUserReader
    {
        public bool PasswordValid(User user, string input)
        {
            throw new NotImplementedException();
        }

        public bool TryGetByName(string name, out User user)
        {
            user = new User();
            user.ID = Guid.NewGuid();
            user.Password = "password";
            user.Adress = new Adress();

            return true;
        }
    }
}
