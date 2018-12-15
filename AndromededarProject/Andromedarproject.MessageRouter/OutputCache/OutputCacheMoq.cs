using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Output;

namespace Andromedarproject.MessageRouter.OutputCache
{
    public class OutputCacheMoq<TContent> : IOutputCache<TContent>
    {
        public async Task Push(BasicOutputMessage<TContent> message)
        {
            
        }
    }
}
