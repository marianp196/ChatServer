using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.OutputCache
{
    public interface IOutputCache<TContent>
    {
        Task Push(OutputDto<TContent> message);
    }
}
