using Andromedarproject.MessageDto.Input;

namespace Andromedarproject.MessageRouter.MessageRouterInput
{
    public interface IRouterInput
    {
        void Rout(BasicInputMessage basicInputMessage);
    }
}
