using System;
using System.Collections.Generic;
using System.Text;
using Andromedarproject.MessageDto.Adresses;

namespace Andromedarproject.MessageRouter.Services.ContentRouters
{
    public abstract class BasicRouter<TContent> : IContentRouter<TContent>
    {
        protected BasicRouter(IContentRouter<TContent> next)
        {
            _next = next;
        }

        public abstract void Rout(Adress sender, Adress target, TContent content);

        protected void Next(Adress sender, Adress target, TContent content)
        {
            if (_next != null)
                _next.Rout(sender, target, content);
        }

        private readonly IContentRouter<TContent> _next;
    }
}
