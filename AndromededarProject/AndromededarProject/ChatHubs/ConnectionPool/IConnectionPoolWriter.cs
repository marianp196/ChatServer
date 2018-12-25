using Andromedarproject.MessageDto.Adresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ConnectionPool
{
    public interface IConnectionPoolWriter<TConnectionId>
    {
        Task Push(string user, TConnectionId connectionId);
        void Remove(string user);
    }
}
