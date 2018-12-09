using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentRouters
{
    public interface IContentRouter<TContent>
    {
        void Rout(Adress sender, Adress target, TContent content);
    }
}
