using System.Collections.Generic;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware.ValidatorServices
{
    public interface IValidator<T>
    {
        Task<IEnumerable<Violation>> Validate(T obj);
    }
}
