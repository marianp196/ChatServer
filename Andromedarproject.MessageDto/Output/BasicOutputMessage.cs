using Andromedarproject.MessageDto.Adresses;

namespace Andromedarproject.MessageDto.Output
{
    public class BasicOutputMessage
    {
        public Adress Sender { get; set; }
        public Adress SenderGroup { get; set; }

        public Adress Target { get; set; } 
        public EMessageTypes MessageType { get; set; }

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
