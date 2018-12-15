using Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.ValidatorServices
{
    public interface IValidator<T>
    {
        Task<IEnumerable<Violation>> Validate(T obj);
    }
}
