using System;
using System.Collections.Generic;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Output.Abstractions;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.TargetTypeCases;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders
{
    public class MessageSender<TContent> : BasicRouter<TContent>
    {      

        public MessageSender(IEnumerable<ITargetTypeCase<TContent>> messageTypeCases,
                                                IOutput<TContent> output,
                                                IContentRouter<TContent> next) : base(next)
        {
            _messageTypeCases = messageTypeCases ?? throw new ArgumentNullException(nameof(messageTypeCases));
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override void Rout(Adress sender, Adress target, TContent content)
        {
            ITargetTypeCase<TContent> messageTypeCase = getCase(target.AdressType);
            if (messageTypeCase == null)
                throw new Exception("Address Type not Known. Can't be routed");

            var outputMessages = messageTypeCase.GetOutputs(sender, target, content);

            foreach (var outputMessage in outputMessages)
                _output.Send(outputMessage);

            Next(sender, target, content);
        }

        private ITargetTypeCase<TContent> getCase(EAdressType adressType)
        {
            foreach (var messageCase in _messageTypeCases)
                if (messageCase.IsResponsible(adressType))
                    return messageCase;
            return null;
        }

        private readonly IEnumerable<ITargetTypeCase<TContent>> _messageTypeCases;
        private readonly IOutput<TContent> _output;
    }
}
