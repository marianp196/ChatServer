﻿using Andromedarproject.MessageDto.Adresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Authetication
{

    //ToDo auf ChatProtokoll-Paket verlagern
    public class AuthenticationDto
    {
        public string Name { get; set; } 
		public string Password { get; set; }
    }
}
