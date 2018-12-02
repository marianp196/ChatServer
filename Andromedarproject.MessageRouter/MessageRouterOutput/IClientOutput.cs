using Andromedarproject.MessageDto.Output;

namespace Andromedarproject.MessageRouter.MessageRouterOutput
{
    public interface IClientOutput
    {
        void Send(BasicOutputMessage basicOutputMessage);
    }
}
