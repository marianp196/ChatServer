using Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware.ValidatorServices;
using System.Collections.Generic;


namespace Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware
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
