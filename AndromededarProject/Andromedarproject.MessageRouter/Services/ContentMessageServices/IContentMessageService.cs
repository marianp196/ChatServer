using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices
{
    public interface IContentRouter<TContent>
    {
        Task Rout(Adress sender, Adress target, TContent content);
    }
}
