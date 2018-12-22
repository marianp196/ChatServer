using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.Output.NetworkAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Output.OutputCache
{
    public interface IOutputCache<TContent>
    {
        Task Push(OutputDto<TContent> message);
    }
}
