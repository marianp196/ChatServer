using System;
using System.Collections.Generic;
using System.Text;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Services.AdressValidator.Exceptions;
using Andromedarproject.MessageRouter.Settings;
using Andromedarproject.Users.Abstractions;

namespace Andromedarproject.MessageRouter.Services.AdressValidator
{
    public class SenderAddressValidator : ISenderAddressValidator
    {
        public SenderAddressValidator(IAddressValidator addressVaidator, IInstanceInformation instanceInforrmation)
        {
            _addressVaidator = addressVaidator ?? throw new ArgumentNullException(nameof(addressVaidator));
            _instanceInforrmation = instanceInforrmation ?? throw new ArgumentNullException(nameof(instanceInforrmation)); ;
        }

        public void Validate(Adress address)
        {
            if (!address.IsOnHomeServerByProtocoll(_instanceInforrmation.Name()))
                throw new SenderNotValidException("Not on this server");
            if(address.AdressType != EAdressType.User)
                throw new SenderNotValidException("Sender has to be User");
            _addressVaidator.Validate(address);
        }

        private readonly IAddressValidator _addressVaidator;
        private readonly IInstanceInformation _instanceInforrmation;
    }
}
