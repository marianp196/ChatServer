using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices
{
    public abstract class BasicRouter<TContent> : IContentRouter<TContent>
    {
        protected BasicRouter(IContentRouter<TContent> next)
        {
            _next = next;
        }

        public abstract Task Rout(Adress sender, Adress target, TContent content);

        protected async Task Next(Adress sender, Adress target, TContent content)
        {
            if (_next != null)
                await _next.Rout(sender, target, content);
        }

        private readonly IContentRouter<TContent> _next;
    }
}
