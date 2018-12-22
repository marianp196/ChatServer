using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware.ValidatorServices
{
    public interface IValidatorService<T>
    {
        Task<ValidationResult> Validate(T obj);
    }

    public class ValidationResult
    {
        public IEnumerable<Violation> Violations { get; set; }

        public bool IsViolated()
        {
            return Violations.Where(v => v.Type == EViolationType.Error).Count() > 0;
        }
    }

    public class Violation
    {
        public EViolationType Type { get; set; }
        public string Message { get; set;}
        public string Code { get; set; }
    }

    public enum EViolationType
    {
        Error = 0,
        Warning = 0
    }
}
