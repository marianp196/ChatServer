using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Output.Moq
{
    public class ConsoleServerOutput<TContent> : IServerOutput<TContent>
    {
        public async Task Send(BasicOutputMessage<TContent> message)
        {
            Console.WriteLine("Server: " + message.Target.Name);
        }
    }
}

