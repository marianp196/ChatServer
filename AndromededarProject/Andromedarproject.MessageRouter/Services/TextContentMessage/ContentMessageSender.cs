using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.BasicMessagePipe.TextContentMessage.OutputGenerators;
using Andromedarproject.MessageRouter.Output.OutputServices;
using Andromedarproject.Output.NetworkAccess;

namespace Andromedarproject.MessageRouter.BasicMessagePipe.TextContentMessage
{
    public class ContentMessageSender<TContent> : BasicRouter<TContent>
    {

        public ContentMessageSender(IEnumerable<IOutputGenerator<TContent>> messageTypeCases,
                                                IOutputService<TContent> output,
                                                IContentRouter<TContent> next) : base(next)
        {
            _messageTypeCases = messageTypeCases ?? throw new ArgumentNullException(nameof(messageTypeCases));
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override async Task Rout(UserDto user, Message<TContent> message)
        {
            await Rout(message);
            await Next(user, message);
        }

        private async Task Rout(Message<TContent> message)
        {
            IOutputGenerator<TContent> messageTypeCase = getCase(message.Traget.AdressType);
            if (messageTypeCase == null)
                throw new Exception("Address Type not Known. Can't be routed");

            var outputMessages = await messageTypeCase.GetOutputs(message);

            foreach (var outputMessage in outputMessages)
                await SendMessage(outputMessage);
            
        }

        private async Task SendMessage(OutputDto<TContent> outputMessage)
        {
            var sendResult = await _output.Send(outputMessage);
            if (sendResult == EResult.Error)
                throw new SendErrorException("Can't be Routed");
        }

        private IOutputGenerator<TContent> getCase(EAdressType adressType)
        {
            foreach (var messageCase in _messageTypeCases)
                if (messageCase.IsResponsible(adressType))
                    return messageCase;
            return null;
        }        

        private readonly IEnumerable<IOutputGenerator<TContent>> _messageTypeCases;
        private readonly IOutputService<TContent> _output;
    }
}

