using Andromedarproject.MessageDto.Attechments;
using System.Collections.Generic;

namespace Andromedarproject.MessageDto.Contents
{
    public class TextContent
    {       
        public IEnumerable<Attechment> Attechments { get; set; }
        public IEnumerable<string> Text{ get; set; }       
    }
}