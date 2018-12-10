using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output.Abstractions;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Output.Moq
{
    public class ConsoleClientOutput<TContent> : IClientOutput<TContent>
    {
        public ConsoleClientOutput(IHubCallerClients clients)
        {
            _clients = clients;
        }

        public async Task Send(BasicOutputMessage<TContent> message)
        {
            Console.WriteLine("Client: " + message.Target.Name);
        }

        private IHubCallerClients _clients;       
    }
}
