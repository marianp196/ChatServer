using Andromedarproject.MessageRouter.Output.OutputCache;
using Andromedarproject.Output.NetworkAccess;
using System;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Output.OutputServices
{
    public class CachedOutputService<TContent> : IOutputService<TContent>
    {
        public CachedOutputService(IOutputCache<TContent> cache, IOutputService<TContent> networkAccess)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _networkAccess = networkAccess ?? throw new ArgumentNullException(nameof(networkAccess));
        }

        public async Task<EResult> Send(OutputDto<TContent> message)
        {
            EResult result = await _networkAccess.Send(message);

            if(result == EResult.CantBeSended)
            {
                await _cache.Push(message);
                result = EResult.Cached;
            }

            return result;
        }

        private readonly IOutputCache<TContent> _cache;
        private readonly IOutputService<TContent> _networkAccess;
    }
}
