using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.Output.NetworkAccess;

namespace Andromedarproject.MessageRouter.Output.OutputCache
{
    public class InMemoryCache<TContent> : IOutputCache<TContent>, ICacheReader<TContent>
    {
        public InMemoryCache()
        {
            _cache = new Dictionary<Guid, OutputDto<TContent>>();
        }

        public async Task Push(OutputDto<TContent> message)
        {
            _cache.Add(message.Id, message);
        }

        public async Task<IEnumerable<OutputDto<TContent>>> GetByAdress(Adress adress)
        {
            var result = _cache.Where(kvp => kvp.Value.Traget.Equals(adress)).
                                            Select(x => x.Value);
            return result;
            
        }

        private IDictionary<Guid, OutputDto<TContent>> _cache;       
    }
}
