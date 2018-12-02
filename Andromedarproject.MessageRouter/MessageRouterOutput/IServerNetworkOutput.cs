using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.MessageRouterOutput
{
    public interface IServerNetworkOutput
    {
        void Send(BasicOutputMessage basicOutputMessage);
    }
}
