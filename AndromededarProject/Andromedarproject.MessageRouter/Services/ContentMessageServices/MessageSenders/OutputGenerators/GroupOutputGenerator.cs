using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Services.OutputServices.MessageInputOutputConverter;
using Andromedarproject.Users.Abstractions.Groups;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators
{
    public class GroupOutputGenerator<TContent> : OutputGenerator<TContent>
    {       

        public GroupOutputGenerator(IInputOutputConverter<TContent> converter, IGroupReader groupReader) : base(converter)
        {
            _groupReader = groupReader ?? throw new ArgumentNullException(nameof(groupReader));
        }

        public override async Task<IEnumerable<BasicOutputMessage<TContent>>> GetOutputs(Adress sender, Adress target, TContent content)
        {
            if (!IsResponsible(target.AdressType))
                throw new Exception("Not responsible");

            var groupResult = await _groupReader.GetGroup(target.Name);
            if (!groupResult.Success)
                throw new Exception("Cant find group");

            var group = groupResult.Value;
            var resultList = new List<BasicOutputMessage<TContent>>();
            foreach (var user in group.Users)
                resultList.Add(Convert(sender, user.Adress, target, content));

            return resultList;
                
        }

        public override bool IsResponsible(EAdressType messageType)
        {
            return messageType == EAdressType.Group;
        }

        private readonly IGroupReader _groupReader;
    }
}
