using Andromedarproject.MessageRouter.Output;
using Andromedarproject.Output.NetworkAccess;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Output.OutputServices
{
    public interface IOutputService<TContent>
    {
        Task<EResult> Send(OutputDto<TContent> message);
    }

    
    public enum EResult
    {
        Success = 0,
        Error = 1,
        CantBeSended = 2,
        Cached = 3
    }
}
