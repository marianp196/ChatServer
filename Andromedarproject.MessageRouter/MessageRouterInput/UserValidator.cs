using Andromedarproject.MessageDto.Input;
using Andromedarproject.MessageRouter.MessageRouterInput.Exceptions;
using Andromedarproject.MessageRouter.MessageRouterInput.Users;
using System;

namespace Andromedarproject.MessageRouter.MessageRouterInput
{
    public class UserValidator : IRouterInput
    {
        public UserValidator(IRouterInput routerInput, IUserReader userReader)
        {
            _routerInput = routerInput ?? throw new ArgumentNullException(nameof(routerInput));
            _userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
        }

        public void Rout(BasicInputMessage basicInputMessage)
        {
            string userName = basicInputMessage.Sender.Name;
            validOrThrowException(basicInputMessage, userName);

            _routerInput.Rout(basicInputMessage);

        }

        private void validOrThrowException(BasicInputMessage basicInputMessage, string userName)
        {
            User user;
            if (!_userReader.TryGetByName(userName, out user))
                throw new UserNotExistsException(userName);
            if (!_userReader.PasswordValid(user, basicInputMessage.AuthString))
                throw new PasswordNotValidException(userName);
        }

        private readonly IRouterInput _routerInput;
        private readonly IUserReader _userReader;
    }
}
