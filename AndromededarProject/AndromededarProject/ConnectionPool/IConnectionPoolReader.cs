using Andromedarproject.MessageDto.Adresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ConnectionPool
{
    public interface IConnectionPoolReader<TConnectionID>
    {
        bool TryRead(Adress adress, out TConnectionID connectionID);
    }
}
