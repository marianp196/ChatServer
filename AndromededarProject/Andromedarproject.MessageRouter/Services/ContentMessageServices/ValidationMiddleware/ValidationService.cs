using Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.ValidatorServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware
{
    public class ValidationService<TContent> : BasicRouter<TContent>
    {
        public ValidationService(IValidatorService<Message<TContent>> validatorService, 
                                            IContentRouter<TContent> next) : base(next)
        {
            _validatorService = validatorService ?? throw new ArgumentNullException(nameof(validatorService));
        }

        public override async Task Rout(UserDto user, Message<TContent> message)
        {
            var result = await _validatorService.Validate(message);
            if (result.IsViolated())
                throw result.CreateNotValidException();
            else
                await Next(user, message);
        }

        private readonly IValidatorService<Message<TContent>> _validatorService;
    }
}
