using System;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.Validators
{
    public class ContentMessageInputValidator<TContent> : BasicRouter<TContent>
    {
        public ContentMessageInputValidator(IContentRouter<TContent> next) : base(next)
        {
        }

        public override async Task Rout(Adress sender, Adress target, TContent content)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(target));
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (content == null)
                throw new ArgumentNullException(nameof(target));

            await base.Next(sender, target, content);
        }
    }
}
