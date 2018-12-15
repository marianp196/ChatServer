using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageDto.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.Shared.OutputServices
{
    public interface IOutputService<TContent>
    {
        Task<EResult> Send(Adress Sender, Adress TargetUser, Adress TargetGroup, TContent content);
        Task<EResult> Send(Adress Sender, Adress TargetUser, TContent content);
    }
    
    public enum EResult
    {
        Success = 0,
        Error = 1,
        Cached = 2
    }
}
