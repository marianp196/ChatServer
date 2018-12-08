using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.Users.Abstractions.Groups
{
    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
