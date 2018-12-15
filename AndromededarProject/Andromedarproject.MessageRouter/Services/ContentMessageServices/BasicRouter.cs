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
       

        protected async Task Next(UserDto user, Message<TContent> message)
        {
            if (_next != null)
                await _next.Rout(user, message);
        }

        public abstract Task Rout(UserDto user, Message<TContent> message);

        private readonly IContentRouter<TContent> _next;
    }
}
