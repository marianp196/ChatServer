using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.Users.Abstractions.Groups
{
    public interface IGroupReader
    {
        bool TryGetByName(string name, out Group group);
    }
}
