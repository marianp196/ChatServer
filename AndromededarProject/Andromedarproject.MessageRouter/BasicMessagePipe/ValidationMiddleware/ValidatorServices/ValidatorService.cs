using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware.ValidatorServices
{
    public class ValidatorService<T> : IValidatorService<T>
    {
        public ValidatorService(IEnumerable<IValidator<T>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async  Task<ValidationResult> Validate(T obj)
        {
            ValidationResult result = new ValidationResult();
            List<Violation> violationList = new List<Violation>();
            result.Violations = violationList;

            foreach (var validator in _validators)
                violationList.AddRange(await validator.Validate(obj));
            
            return result;
        }

        private readonly IEnumerable<IValidator<T>> _validators;       
    }
}
