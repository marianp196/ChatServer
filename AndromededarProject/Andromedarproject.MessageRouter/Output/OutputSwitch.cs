using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output.Abstractions;
using Andromedarproject.MessageRouter.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Output
{
    public class OutputSwitch<TContent> : IOutput<TContent>
    {
        public OutputSwitch(IServerOutput<TContent> serverOutput, IClientOutput<TContent> clinetOutput, IInstanceInformation information)
        {
            _serverOutput = serverOutput ?? throw new ArgumentNullException(nameof(serverOutput));
            _clinetOutput = clinetOutput ?? throw new ArgumentNullException(nameof(clinetOutput));
            _information = information ?? throw new ArgumentNullException(nameof(information));
        }

        public async Task Send(BasicOutputMessage<TContent> message)
        {
            if (message.Target.IsOnHomeServerByProtocoll(_information.Name()))
                _clinetOutput.Send(message);
            else
                _serverOutput.Send(message);
        }

        private readonly IServerOutput<TContent> _serverOutput;
        private readonly IClientOutput<TContent> _clinetOutput;
        private readonly IInstanceInformation _information;
    }
}
