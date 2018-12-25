using Andromedarproject.MessageDto.Output;
using Andromedarproject.Output.NetworkAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Output.ServerClients
{
    public static class MessageOutExtension
    {
        public static BasicOutputMessage<TContent> Convert<TContent>(this OutputDto<TContent> output)
        {
            var result = new BasicOutputMessage<TContent>();

            result.Sender = output.UserSender;
            result.SenderGroup = output.GroupSender;
            result.Target = output.Traget;
            result.ServerId = output.Id;
            result.Target = output.Traget;

            return result;
        }
    }
}
