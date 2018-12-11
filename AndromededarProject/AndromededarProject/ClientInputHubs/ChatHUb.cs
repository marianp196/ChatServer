using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Services.ContentMessageServices;
using Andromedarproject.Users.Abstractions;
using AndromededarProject.Web.Authetication;
using AndromededarProject.Web.ConnectionPool;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ClientInputHubs
{
    public class ChatHub : Hub
    {
        public ChatHub(IContentRouter<TextContent> router, IConnectionPool connectionPool)
        {
            _router = router;
            _connectionPool = connectionPool;
        }

        public async Task InitConnection(string user, AuthenticationDto message)
        {
            //ToDo geschiet mmit Adresse anmelden
            //Passwort lesen
            //Nachrichten aus Container holen
            _connectionPool.Add(message.Adress, Context.ConnectionId);
        }

        public async Task SendTextMessage(string user, BasicInputMessage<TextContent> message)
        {
            if (!_connectionPool.TryGetValue(message.Sender, out var obj))
                return;

            await _router.Rout(message.Sender, message.Target, message.Content);            
            //await Clients.Client(Context.ConnectionId).SendAsync("ReceiveTextMessage", new BasicOutputMessage<TextContent>());
        }


        private readonly IContentRouter<TextContent> _router;
        private readonly IConnectionPool _connectionPool;
    }
}
