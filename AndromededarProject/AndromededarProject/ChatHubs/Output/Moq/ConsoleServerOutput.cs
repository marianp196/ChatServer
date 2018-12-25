using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.Output.NetworkAccess;
using System;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Output.Moq
{
    public class ConsoleServerOutput<TContent> : IServerOutput<TContent>
    {
        public async Task<bool> Send(OutputDto<TContent> message)
        {
            Console.WriteLine("Server: " + message.Traget.Name);
            return true;
        }
    }
}

