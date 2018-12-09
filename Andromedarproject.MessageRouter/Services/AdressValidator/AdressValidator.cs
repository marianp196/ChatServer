using System;
using System.Collections.Generic;
using System.Text;
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

        public void Validate(Adress address)
        {
            if (!address.isValid())
                throw new AdressNotValidException("sender");
            if (!address.IsOnHomeServerByProtocoll(_instanceInforrmation.Name()))
                return;
            //Todo hier broadcast ausschließemn
            checkIfExists(address);
        }

        private void checkIfExists(Adress address)
        {
            if (address.AdressType == EAdressType.User)
                checkUserExists(address.Name);
            else if (address.AdressType == EAdressType.Group)
                checkGroupExists(address.Name);
        }

        private void checkGroupExists(string name)
        {
            if (!_groupReader.TryGetByName(name, out var obj))
                throw new AdressNotValidException("Group doesn't exist");
        }

        private void checkUserExists(string name)
        {
            if (!_userReader.TryGetByName(name, out var obj))
                throw new AdressNotValidException("Address doesn't exist");
            
        }

        private readonly IUserReader _userReader;
        private readonly IGroupReader _groupReader;
        private readonly IInstanceInformation _instanceInforrmation;
    }
}
