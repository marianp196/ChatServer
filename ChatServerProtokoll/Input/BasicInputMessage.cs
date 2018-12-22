using Andromedarproject.MessageDto.Adresses;
using System;

namespace Andromedarproject.MessageDto.Input
{
    public class BasicInputMessage<TContent>
    {
        public Guid? Id { get; set; } 

        public Adress Target { get; set; }
        public Adress Sender { get; set; }

        public TContent Content { get; set; }

        /// <summary>
        /// Senderadresse muss gesetzt sein und Valide
        /// Target kann gesetzt sein, uss valide sein, wenn gestezt ist
        /// Alles andere optional.
        /// </summary>
        /// <returns></returns>
        public virtual bool isValid()
        {
            if (Sender == null || !Sender.isValid())
                return false;
            if (Target != null && !Target.isValid())
                return false;
           
            return true;

        }
    }
}
