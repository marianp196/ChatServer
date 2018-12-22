using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.Output.NetworkAccess;
using AndromededarProject.Web.ClientInputHubs;
using AndromededarProject.Web.ConnectionPool;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Output.ServerClients
{
    public class ClientOutput<TContent> : IClientOutput<TContent>
    {
        public ClientOutput(IHubContext<ChatHub> context, IConnectionPool connectionPool)
        {
            _context = context;
            _connectionPool = connectionPool;
        }

        /*public async Task<bool> Send(BasicOutputMessage<TContent> message)
        {
            if (!_connectionPool.TryGetValue(message.Target, out var connectionId))
                return false;

            await _context.Clients.Client(connectionId).SendAsync("ReceiveTextMessage", message);
            return true;
        }*/

        public async Task<bool> Send(OutputDto<TContent> message)
        {
            
            return true;
        }

        private IHubContext<ChatHub> _context;
        private readonly IConnectionPool _connectionPool;
    }
}
