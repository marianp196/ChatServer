using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Services.AdressValidator;
using System;

namespace Andromedarproject.MessageRouter.Services.ContentRouters.Validators
{
    public class ContentRouterInputSenderValidator<TContent> : BasicRouter<TContent>
    {
        public ContentRouterInputSenderValidator(IContentRouter<TContent> next, ISenderAddressValidator senderAdressValidator) : base(next)
        {
            _senderAdressValidator = senderAdressValidator ?? throw new ArgumentNullException(nameof(senderAdressValidator));
        }

        public override void Rout(Adress sender, Adress target, TContent content)
        {
            _senderAdressValidator.Validate(sender);
            base.Next(sender, target, content);
        }

        private readonly ISenderAddressValidator _senderAdressValidator;
    }
}
