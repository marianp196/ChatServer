using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Output.Abstractions
{


    public interface IOutput<TContent>
    {
        Task<bool> Send(BasicOutputMessage<TContent> message);
    }

    public interface IServerOutput<TContent> : IOutput<TContent>
    {}

    public interface IClientOutput<TContent> : IOutput<TContent>
    {}    
}
