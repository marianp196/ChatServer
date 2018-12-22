using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware.ValidatorServices;
using Andromedarproject.MessageRouter.Settings;
using Andromedarproject.Users.Abstractions;
using Andromedarproject.Users.Abstractions.Groups;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware.Validators
{
    public class TargetAdressValidator<TContent> : IValidator<Message<TContent>>
    {
        public TargetAdressValidator(IUserReader userReader, IGroupReader groupReader, IInstanceInformation instanceInforrmation)
        {
            _userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
            _groupReader = groupReader ?? throw new ArgumentNullException(nameof(groupReader));
            _instanceInforrmation = instanceInforrmation ?? throw new ArgumentNullException(nameof(instanceInforrmation));
        }

        public async  Task<IEnumerable<Violation>> Validate(Message<TContent> obj)
        {
            var result = new List<Violation>();
            if(obj.Traget == null)
            {
                result.Add(new Violation { Type = EViolationType.Error, Code = "TARSET", Message = "Target not set" });
                return result;
            }

            if (!obj.Traget.isValid())
            {
                result.Add(new Violation { Type = EViolationType.Error, Code = "TARVAL", Message = "Target not valid" });
                return result;
            }

            if (!await validateIfExists(obj.Traget))
                result.Add(new Violation { Type = EViolationType.Error,  Message = "Target doesn't exists", Code = "TARNOTFOUND" });

            return result;
        }

        private async Task<bool> validateIfExists(Adress address)
        {
            if (!address.IsOnHomeServerByProtocoll(_instanceInforrmation.Name()))
                return true;
            return await checkIfExists(address);
        }

        private async Task<bool> checkIfExists(Adress address)
        {
            //Todo hier broadcast ausschließemn
            if (address.AdressType == EAdressType.User)
                return await checkUserExists(address.Name);
            else if (address.AdressType == EAdressType.Group)
                return await checkGroupExists(address.Name);
            else
                throw new InvalidOperationException("adresstype not known");                
        }

        private async Task<bool> checkGroupExists(string name)
        {
            var result = await _groupReader.GetGroup(name);
            return result.Success;
        }

        private async Task<bool> checkUserExists(string name)
        {
            var result = await _userReader.GetUserByAdressname(name);
            return result.Success;
        }

        private readonly IUserReader _userReader;
        private readonly IGroupReader _groupReader;
        private readonly IInstanceInformation _instanceInforrmation;

       
    }
}
