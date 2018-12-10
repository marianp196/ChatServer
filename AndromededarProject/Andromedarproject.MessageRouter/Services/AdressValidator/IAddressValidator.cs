using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.AdressValidator
{
    public interface IAddressValidator
    {
        Task Validate(Adress address);
    }

    public interface ISenderAddressValidator : IAddressValidator
    {}

    public interface ITargetAddressValidator : IAddressValidator
    {}
}
