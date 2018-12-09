using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageDto.Adresses
{
    public class Adress
    {
        public EAdressType AdressType { get; set;}
        public string Name { get; set; }
        public string Server { get; set; }

        public bool isValid()
        {
            if (Name == null || Name == "" || Server == null || Server == "")
                return false;
            if (Name.Contains(":") || Server.Contains(":"))
                return false;

            return true;
        } 

        public string GetName()
        {
            return Server + "::" + Name + "::" + AdressType.ToString();
        }

        public bool IsOnHomeServerByProtocoll(string serverName)
        {
            return Server.ToLower() == "home" || serverName.ToLower() == Server.ToLower();
        }

        public override bool Equals(object obj)
        {
            var adress = obj as Adress;
            return adress != null &&
                   AdressType == adress.AdressType &&
                   Name == adress.Name &&
                   Server == adress.Server;
        }
    }
}
