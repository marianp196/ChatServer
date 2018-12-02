using Andromedarproject.MessageDto.Adresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.MessageRouterInput.Users
{
    public class User
    {
        public Guid ID {get; set;}
        public Adress  Adress{ get; set; }
        public string Password { get; set; }
    }
}
