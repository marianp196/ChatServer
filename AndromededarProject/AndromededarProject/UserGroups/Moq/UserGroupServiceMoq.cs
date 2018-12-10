using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.Users.Abstractions;
using Andromedarproject.Users.Abstractions.Groups;
using Andromedarproject.Users.Abstractions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.UserGroups.Moq
{
    public class UserGroupServiceMoq : IUserReader, IGroupReader
    {
        public UserGroupServiceMoq() {
            Group group = new Group();
            group.Name = "group";
            var usrs = new List<User>();
            group.Users = usrs;
            _group = group;
            

            var user = new User();
            user.ID = Guid.NewGuid();
            user.Password = "password";
            user.Adress = new Adress();
            user.Adress.Name = "adress1";
            user.Adress.Server = "MyHome";
            _users.Add(user.ID, user);
            usrs.Add(user);

            user = new User();
            user.ID = Guid.NewGuid();
            user.Password = "password";
            user.Adress = new Adress();
            user.Adress.Name = "adress2";
            user.Adress.Server = "MyHome";
            _users.Add(user.ID, user);
            usrs.Add(user);
        }

        public bool PasswordValid(User user, string input)
        {
            return true;
        }

        public async Task<Result<User>> GetUser(string name)
        {
            var result = new Result<User>();
            result.Value = _users.Where(kvp => kvp.Value.Adress.Name == name).Select(x => x.Value).FirstOrDefault();
            result.Success = result.Value != null;
            return result;
        }

        public async  Task<Result<Group>> GetGroup(string name)
        {
            var result = new Result<Group>();
            if (name != _group.Name)
                return result; ;
            result.Success = true;
            result.Value = _group;
            return result;
        }

        private IDictionary<Guid, User> _users = new Dictionary<Guid, User>();
        private Group _group;
    }
}
