using Andromedarproject.MessageDto.Adresses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.BasicMessagePipe
{
    public interface IContentRouter<TContent>
    {
        Task Rout(UserDto user, Message<TContent> message);
    }

    public class Message<TContent>
    {
        public Message()
        {
            ServerId = Guid.NewGuid();
            ServerTimeStamp = DateTime.UtcNow;
        }

        //Server Data
        public Guid ServerId { get; }
        public DateTime ServerTimeStamp { get; }

        //Client Data
        public Guid? ClientMessageId { get; set; }
        public DateTime? ClientTimestamp { get; set; }

        public Adress Sender { get; set; }
        public Adress Traget { get; set; }

        public TContent Content { get; set; }
    }

    public class UserDto
    {
        public string Name { get; set; }
    }

    public class NotValidException : Exception
    {
        public NotValidException(string message) : base(message)
        {
        }

        public NotValidException(IEnumerable<MessageViolation> violations) : base()
        {
            MessageViolations = violations;
        }

        public IEnumerable<MessageViolation> MessageViolations { get; }
    }

    public class SendErrorException : Exception
    {
        public SendErrorException(string message) : base(message)
        {
        }
    }

    public class MessageViolation
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }
}
