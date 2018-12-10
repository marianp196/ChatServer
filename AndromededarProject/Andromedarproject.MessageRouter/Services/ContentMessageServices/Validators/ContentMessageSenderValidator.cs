using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Services.AdressValidator;
using System;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.Validators
{
    public class ContentMessageSenderValidator<TContent> : BasicRouter<TContent>
    {
        public ContentMessageSenderValidator(ISenderAddressValidator senderAdressValidator, IContentRouter<TContent> next) : base(next)
        {
            _senderAdressValidator = senderAdressValidator ?? throw new ArgumentNullException(nameof(senderAdressValidator));
        }

        public override async Task Rout(Adress sender, Adress target, TContent content)
        {
            _senderAdressValidator.Validate(sender);
            await base.Next(sender, target, content);
        }

        private readonly ISenderAddressValidator _senderAdressValidator;
    }
}
