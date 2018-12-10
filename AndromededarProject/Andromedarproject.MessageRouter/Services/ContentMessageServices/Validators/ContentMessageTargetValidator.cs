using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Services.AdressValidator;
using System;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.Validators
{
    public class ContentRouterInputTargetValidator<TContent> : BasicRouter<TContent>
    {
        public ContentRouterInputTargetValidator(ITargetAddressValidator validator, IContentRouter<TContent> next) : base(next)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public override async Task Rout(Adress sender, Adress target, TContent content)
        {
            _validator.Validate(target);
            await base.Next(sender, target, content);
        }

        private readonly ITargetAddressValidator _validator;
    }
}
