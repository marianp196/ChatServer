using Andromedarproject.MessageDto.Adresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ConnectionPool
{
    public interface IConnectionPool : IDictionary<Adress, string>
    {       
    }
}
