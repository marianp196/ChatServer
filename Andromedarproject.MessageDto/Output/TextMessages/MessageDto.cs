using Andromedarproject.MessageDto.Attechments;
using System.Collections.Generic;

namespace Andromedarproject.MessageDto.Output.TextMessages
{
    public class MessageDto : BasicOutputMessage
    {       
        public IEnumerable<Attechment> Attechments { get; set; }
        public IEnumerable<string> Content{ get; set; }       
    }
}
