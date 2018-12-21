using Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.ValidatorServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.Validators
{
    public class MetaDataValidator<TContent> : IValidator<Message<TContent>>
    {
        public async Task<IEnumerable<Violation>> Validate(Message<TContent> obj)
        {
            var result = new List<Violation>();
            if (obj.ClientTimestamp == null || obj.ClientTimestamp > DateTime.UtcNow)
                result.Add(new Violation { Type = EViolationType.Error, Code = "METTIM", Message = "Timestamp is invalid" });
            if (obj.ClientMessageId == null)
                result.Add(new Violation { Type = EViolationType.Error, Code = "METGID", Message = "Guid is not set" });

            return result;
        }
    }
}
