using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output.Abstractions;
using AndromededarProject.Web.ClientInputHubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Output.Moq
{
    public class ConsoleClientOutput<TContent> : IClientOutput<TContent>
    {
        public ConsoleClientOutput()
        {}

        public async Task<bool> Send(BasicOutputMessage<TContent> message)
        {
            Console.WriteLine(message.Content);
            return true;
        }
      
    }
}
