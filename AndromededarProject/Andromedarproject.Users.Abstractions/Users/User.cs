
using Andromedarproject.MessageDto.Adresses;
using System;

namespace Andromedarproject.Users.Abstractions
{
    public class User
    {
        public Guid ID {get; set;}
        public string Name { get; set; }
        public Adress  Adress{ get; set; }
        public string Password { get; set; }
    }
}
