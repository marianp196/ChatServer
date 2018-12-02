using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageDto.Adresses
{
    public enum EAdressType
    {
        User = 0,
        Group = 1,
        IntrenalGroup = 2, //für sowas wie statusnachrichten
        ServerBroadcast = 3
    }
}
