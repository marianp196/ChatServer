﻿using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.RouterOutput.Abstractions
{
    public interface IOutput<TContent>
    {
        void Send(BasicOutputMessage<TContent> message);
    }

    public interface IServerOutput<TContent> : IOutput<TContent>
    {}

    public interface IClientOutput<TContent> : IOutput<TContent>
    {}
}
