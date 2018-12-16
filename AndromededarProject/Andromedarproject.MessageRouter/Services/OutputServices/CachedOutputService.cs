using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Output;

namespace Andromedarproject.MessageRouter.Services.OutputServices
{
    public class CachedOutputService<TContent> : IOutputService<TContent>
    {
        public Task<EResult> Send(OutputDto<TContent> message)
        {
            throw new NotImplementedException();
        }
    }
}
