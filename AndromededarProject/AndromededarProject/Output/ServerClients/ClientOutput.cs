using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output.Abstractions;
using AndromededarProject.Web.ClientInputHubs;
using AndromededarProject.Web.ConnectionPool;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Send(BasicOutputMessage<TContent> message)
        {
            if (!_connectionPool.TryGetValue(message.Target, out var connectionId))
                return;

            await _context.Clients.Client(connectionId).SendAsync("ReceiveTextMessage", message);
        }
        private IHubContext<ChatHub> _context;
        private readonly IConnectionPool _connectionPool;
    }
}
