using System;
using System.Threading.Tasks;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.MessageRouter.Settings;
using Andromedarproject.Output.NetworkAccess;

namespace Andromedarproject.MessageRouter.Output.OutputServices
{
    public class OutputSwitchService<TContent> : IOutputService<TContent>
    {

        public OutputSwitchService(IServerOutput<TContent> serverOutput, IClientOutput<TContent> clinetOutput, IInstanceInformation information)
        {
            _serverOutput = serverOutput ?? throw new ArgumentNullException(nameof(serverOutput));
            _clinetOutput = clinetOutput ?? throw new ArgumentNullException(nameof(clinetOutput));
            _information = information ?? throw new ArgumentNullException(nameof(information));
        }


        public async Task<EResult> Send(OutputDto<TContent> message)
        {
            bool result = await send(message);
            return result ? EResult.Success : EResult.CantBeSended;
        }

        private async Task<bool> send(OutputDto<TContent> message)
        {
            if (message.Traget.IsOnHomeServerByProtocoll(_information.Name()))
                return await _clinetOutput.Send(message);
            else
                return await _serverOutput.Send(message);
        }

        private readonly IServerOutput<TContent> _serverOutput;
        private readonly IClientOutput<TContent> _clinetOutput;
        private readonly IInstanceInformation _information;
    }
}
