using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.MessageRouter.Services.OutputServices;
using Andromedarproject.MessageRouter.utils;
using Andromedarproject.Users.Abstractions.Groups;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators
{
    public class GroupOutputGenerator<TContent> : OutputGenerator<TContent>
    {       

        public GroupOutputGenerator(IGroupReader groupReader)
        {
            _groupReader = groupReader ?? throw new ArgumentNullException(nameof(groupReader));
        }

        public override bool IsResponsible(EAdressType messageType)
        {
            return messageType == EAdressType.Group;
        }

        public override async Task<IEnumerable<OutputDto<TContent>>> GetOutputs(Message<TContent> input)
        {
            var target = input.Traget;

            if (!IsResponsible(target.AdressType))
                throw new Exception("Not responsible");

            var groupResult = await _groupReader.GetGroup(target.Name);
            if (!groupResult.Success)
                throw new Exception("Cant find group");

            var group = groupResult.Value;
            List<OutputDto<TContent>> resultList = generateOutput(input, group);

            return resultList;
        }

        private List<OutputDto<TContent>> generateOutput(Message<TContent> input, Group group)
        {
            var resultList = new List<OutputDto<TContent>>();
            foreach (var user in group.Users)
            {
                var output = Convert(input);
                output.SenderType = ESenderType.Group;
                output.UserSender = input.Sender;
                output.GroupSender = input.Traget;
                resultList.Add(output.DeepCopy());
            }

            return resultList;
        }
        private readonly IGroupReader _groupReader;
    }
}
