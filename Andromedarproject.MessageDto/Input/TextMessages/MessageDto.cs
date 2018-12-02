using Andromedarproject.MessageDto.Attechments;
using System.Collections.Generic;

namespace Andromedarproject.MessageDto.Input.TextMessages
{
    public class MessageDto : BasicInputMessage
    {       
        public IEnumerable<Attechment> Attechments { get; set; }
        public IEnumerable<string> Content{ get; set; }       
    }
}
