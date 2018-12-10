using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Services.AdressValidator.Exceptions;
using Andromedarproject.MessageRouter.Settings;
using Andromedarproject.Users.Abstractions;
using Andromedarproject.Users.Abstractions.Groups;

namespace Andromedarproject.MessageRouter.Services.AdressValidator
{
    public class AdressValidator : IAddressValidator
    {
        public AdressValidator(IUserReader userReader, IGroupReader groupReader, IInstanceInformation instanceInforrmation)
        {
            _userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
            _groupReader = groupReader ?? throw new ArgumentNullException(nameof(groupReader));
            _instanceInforrmation = instanceInforrmation ?? throw new ArgumentNullException(nameof(instanceInforrmation));
        }

        public async Task Validate(Adress address)
        {
            if (!address.isValid())
                throw new AdressNotValidException("sender");
            if (!address.IsOnHomeServerByProtocoll(_instanceInforrmation.Name()))
                return;
            //Todo hier broadcast ausschließemn
            await checkIfExists(address);
        }

        private async Task checkIfExists(Adress address)
        {
            if (address.AdressType == EAdressType.User)
                await checkUserExists(address.Name);
            else if (address.AdressType == EAdressType.Group)
                await checkGroupExists(address.Name);
        }

        private async Task checkGroupExists(string name)
        {
            var result = await _groupReader.GetGroup(name);
            if (!result.Success)
                throw new AdressNotValidException("Group doesn't exist");
        }

        private async Task checkUserExists(string name)
        {
            var result = await _userReader.GetUser(name);
            if (!result.Success)
                throw new AdressNotValidException("Address doesn't exist");
            
        }

        private readonly IUserReader _userReader;
        private readonly IGroupReader _groupReader;
        private readonly IInstanceInformation _instanceInforrmation;
    }
}
