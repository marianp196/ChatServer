using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Output.Abstractions;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders
{
    public class ContentMessageSender<TContent> : BasicRouter<TContent>
    {      

        public ContentMessageSender(IEnumerable<IOutputGenerator<TContent>> messageTypeCases,
                                                IOutput<TContent> output,
                                                IContentRouter<TContent> next) : base(next)
        {
            _messageTypeCases = messageTypeCases ?? throw new ArgumentNullException(nameof(messageTypeCases));
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override async Task Rout(Adress sender, Adress target, TContent content)
        {
            IOutputGenerator<TContent> messageTypeCase = getCase(target.AdressType);
            if (messageTypeCase == null)
                throw new Exception("Address Type not Known. Can't be routed");

            var outputMessages = await messageTypeCase.GetOutputs(sender, target, content);

            foreach (var outputMessage in outputMessages)
               await _output.Send(outputMessage);

            await Next(sender, target, content);
        }

        private IOutputGenerator<TContent> getCase(EAdressType adressType)
        {
            foreach (var messageCase in _messageTypeCases)
                if (messageCase.IsResponsible(adressType))
                    return messageCase;
            return null;
        }

        private readonly IEnumerable<IOutputGenerator<TContent>> _messageTypeCases;
        private readonly IOutput<TContent> _output;
    }
}
