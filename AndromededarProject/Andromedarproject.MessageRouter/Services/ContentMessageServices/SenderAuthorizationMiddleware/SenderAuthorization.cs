using Andromedarproject.Users.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.SenderAuthorizationMiddleware
{
    public class SenderAuthorization<TContent> : BasicRouter<TContent>
    {
        
        public SenderAuthorization(IUserReader userReader, IContentRouter<TContent> next) : base(next)
        {
            _userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
        }

        public override async Task Rout(UserDto user, Message<TContent> message)
        {
            var result = await _userReader.GetUserByUserName(user.Name);
            if (!result.Success)
                throw new NotValidException("Not authorized");  

            var userAdress = result.Value.Adress;
            if(userAdress== null)
                throw new NotValidException("Not authorized");
            if(!userAdress.Equals(message.Sender))
                throw new NotValidException("SenderAdressNotValid");

            await Next(user, message);
        }

        private readonly IUserReader _userReader;
    }
}
