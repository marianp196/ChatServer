using System;
using Andromedarproject.MessageDto.Adresses;

namespace Andromedarproject.MessageRouter.Services.ContentRouters.Validators
{
    public class ContentRouterInputValidator<TContent> : BasicRouter<TContent>
    {
        public ContentRouterInputValidator(IContentRouter<TContent> next) : base(next)
        {
        }

        public override void Rout(Adress sender, Adress target, TContent content)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(target));
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (content == null)
                throw new ArgumentNullException(nameof(target));

            base.Next(sender, target, content);
        }
    }
}
