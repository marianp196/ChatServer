using Andromedarproject.Users.Abstractions.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.Users.Abstractions.Groups
{
    public interface IGroupReader
    {
        Task<Result<Group>> TryGetByName(string name);
    }
}
