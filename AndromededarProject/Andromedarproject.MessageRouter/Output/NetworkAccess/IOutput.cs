using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.Output.NetworkAccess
{


    public interface IOutput<TContent>
    {
        Task<bool> Send(OutputDto<TContent> message);
    }

    public interface IServerOutput<TContent> : IOutput<TContent>
    {}

    public interface IClientOutput<TContent> : IOutput<TContent>
    {}

    public class OutputDto<TContent>
    {
        public Guid Id { get; set; }
        public DateTime ClientTime { get; set; }

        public ESenderType SenderType { get; set; }
        public Adress UserSender { get; set; }
        public Adress GroupSender { get; set; }

        public Adress Traget { get; set; }

        public TContent Content { get; set; }

    }

    public enum ESenderType
    {
        User = 0,
        Group = 1
    }
}
