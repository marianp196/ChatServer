using System;
using System.Collections.Generic;
using System.Text;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Settings;

namespace Andromedarproject.MessageRouter.Services.AdressValidator
{
    public class TargetAddressValidator : ITargetAddressValidator
    {
        public TargetAddressValidator(IAddressValidator addressVaidator, IInstanceInformation instanceInforrmation)
        {
            _addressVaidator = addressVaidator ?? throw new ArgumentNullException(nameof(addressVaidator));
            _instanceInforrmation = instanceInforrmation ?? throw new ArgumentNullException(nameof(instanceInforrmation)); ;
        }

        public void Validate(Adress address)
        {
            _addressVaidator.Validate(address);
           
        }

        private readonly IAddressValidator _addressVaidator;
        private readonly IInstanceInformation _instanceInforrmation;
    }
}
