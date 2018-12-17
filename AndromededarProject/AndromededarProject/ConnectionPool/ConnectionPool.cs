using Andromedarproject.MessageDto.Adresses;
using System.Collections.Generic;

namespace AndromededarProject.Web.ConnectionPool
{
    public class ConnectionPool : Dictionary<Adress, string>,  IConnectionPool
    {
    }
}
