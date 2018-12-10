using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.Users.Abstractions;
using Andromedarproject.Users.Abstractions.Groups;
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

        public bool TryGetByName(string name, out User user)
        {
            user = _users.Where(kvp => kvp.Value.Adress.Name == name).Select(x => x.Value).FirstOrDefault();
            return user == null ? false : true;                
        }

        public bool TryGetByName(string name, out Group group)
        {
            group = null;
            if (name != _group.Name)
                return false;
            group = _group;
            return true;
        }

        private IDictionary<Guid, User> _users = new Dictionary<Guid, User>();
        private Group _group;
    }
}
