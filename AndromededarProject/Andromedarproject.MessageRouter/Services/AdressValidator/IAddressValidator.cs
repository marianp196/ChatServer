﻿using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.AdressValidator
{
    public interface IAddressValidator
    {
        void Validate(Adress address);
    }

    public interface ISenderAddressValidator : IAddressValidator
    {}

    public interface ITargetAddressValidator : IAddressValidator
    {}
}