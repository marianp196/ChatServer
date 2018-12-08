using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Services.AdressValidator;
using Andromedarproject.MessageRouter.Services.Exceptions;
using Andromedarproject.MessageRouter.Settings;
using Andromedarproject.Users.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentRouters.Validators
{
    public class ContentRouterInputTargetValidator<TContent> : BasicRouter<TContent>
    {
        public ContentRouterInputTargetValidator(IContentRouter<TContent> next, ITargetAddressValidator validator) : base(next)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public override void Rout(Adress sender, Adress target, TContent content)
        {
            _validator.Validate(target);
            base.Next(sender, target, content);
        }

        private readonly ITargetAddressValidator _validator;
    }
}
