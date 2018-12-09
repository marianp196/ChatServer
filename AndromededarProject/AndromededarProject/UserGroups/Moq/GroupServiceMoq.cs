using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.Users.Abstractions;
using Andromedarproject.Users.Abstractions.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.UserGroups.Moq
{
    public class GroupServiceMoq : IGroupReader
    {
        public bool TryGetByName(string name, out Group group)
        {
            throw new NotImplementedException();
        }
    }
}
