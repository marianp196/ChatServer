using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;

namespace Andromedarproject.MessageRouter.Services.Shared.OutputServices
{
    public class CachedOutputService<TContent> : IOutputService<TContent>
    {
        public Task<EResult> Send(Adress Sender, Adress TargetUser, Adress TargetGroup, TContent content)
        {
            throw new NotImplementedException();
        }

        public Task<EResult> Send(Adress Sender, Adress TargetUser, TContent content)
        {
            throw new NotImplementedException();
        }
    }
}
