using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.BasicMessagePipe
{
    public interface IBasicMessagePipeOutput<TContent> : IContentRouter<TContent>
    {
    }
}
