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
        public ClientOutput(IHubContext<ChatHub> context, IConnectionPoolReader<string> connectionPool)
        {
            _context = context;
            _connectionPool = connectionPool;
        }

        public async Task<bool> Send(OutputDto<TContent> message)
        {
            if (!_connectionPool.TryRead(message.Traget, out var connectionId))
                return false;
            try
            {
                await _context.Clients.Client(connectionId)
                    .SendAsync("ReceiveTextMessage", message.Convert());
            }
            catch (Exception e)
            {
                return false;
            }            
            return true;
        }

        private IHubContext<ChatHub> _context;
        private readonly IConnectionPoolReader<string> _connectionPool;
    }
}
