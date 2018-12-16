using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output;
using System;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Output.Moq
{
    public class ConsoleClientOutput<TContent> : IClientOutput<TContent>
    {
        public ConsoleClientOutput()
        {}

        public async Task<bool> Send(OutputDto<TContent> message)
        {
            Console.WriteLine(message.Content);
            return true;
        }
    }
}
