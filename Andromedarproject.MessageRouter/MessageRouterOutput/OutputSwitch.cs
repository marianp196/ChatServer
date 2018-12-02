using System;
using System.Collections.Generic;
using System.Text;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Settings;

namespace Andromedarproject.MessageRouter.MessageRouterOutput
{
    public class OutputSwitch : IOutput
    {       

        public OutputSwitch(IServerNetworkOutput serverOutput, IClientOutput clientOutput, IInstanceInformation serverNetworkInformation)
        {
            _serverOutput = serverOutput ?? throw new ArgumentNullException(nameof(serverOutput));
            _clientOutput = clientOutput ?? throw new ArgumentNullException(nameof(clientOutput));
            _serverNetworkInformation = serverNetworkInformation ?? throw new ArgumentNullException(nameof(serverNetworkInformation));
        }

        public void Send(BasicOutputMessage basicOutputMessage)
        {
            Adress targetAdress = basicOutputMessage.Target;
            if (targetAdress.IsOnHomeServerByProtocoll(_serverNetworkInformation.Name()))
            {
                _clientOutput.Send(basicOutputMessage);
            }
            else
            {
                _serverOutput.Send(basicOutputMessage);
            }
        }

        private readonly IServerNetworkOutput _serverOutput;
        private readonly IClientOutput _clientOutput;
        private readonly IInstanceInformation _serverNetworkInformation;
    }
}
