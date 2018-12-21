using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.MessageRouter.Output;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromedarproject.MessageRouter.Services.OutputCache
{
    public interface ICacheReader<TContent>
    {
        Task<IEnumerable<OutputDto<TContent>>> GetByAdress(Adress adress);
    }
}
