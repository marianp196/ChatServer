using Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.ValidatorServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware
{
    public static class ValidationResultExtension
    {
        public static NotValidException CreateNotValidException(this ValidationResult result)
        {
            var violationList = new List<MessageViolation>();
            foreach (var v in result.Violations)
                violationList.Add(new MessageViolation { Code = v.Code, Text = v.Message });
            return new NotValidException(violationList);
        }
    }
}
