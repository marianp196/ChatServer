using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.OutputCache
{
    public interface IOutputCache<TContent>
    {
        Task Push(BasicOutputMessage<TContent> message);
    }
}
