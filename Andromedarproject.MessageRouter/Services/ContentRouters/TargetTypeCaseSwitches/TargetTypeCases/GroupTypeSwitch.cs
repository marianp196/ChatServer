using System;
using System.Collections.Generic;
using System.Text;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using Andromedarproject.Users.Abstractions.Groups;

namespace Andromedarproject.MessageRouter.Services.ContentRouters.TargetTypeCaseSwitches.TargetTypeCases
{
    public class GroupTypeSwitch<TContent> : TragetTypeCase<TContent>
    {       

        public GroupTypeSwitch(IInputOutputConverter<TContent> converter, IGroupReader groupReader) : base(converter)
        {
            _groupReader = groupReader ?? throw new ArgumentNullException(nameof(groupReader));
        }

        public override IEnumerable<BasicOutputMessage<TContent>> GetOutputs(Adress sender, Adress target, TContent content)
        {
            if (!IsResponsible(target.AdressType))
                throw new Exception("Not responsible");

            if(!_groupReader.TryGetByName(target.Name, out var group))
                throw new Exception("Cant find group");

            var result = new List<BasicOutputMessage<TContent>>();
            foreach (var user in group.Users)
                result.Add(Convert(sender, user.Adress, target, content));

            return result;
                
        }

        public override bool IsResponsible(EAdressType messageType)
        {
            return messageType == EAdressType.Group;
        }

        private readonly IGroupReader _groupReader;
    }
}
