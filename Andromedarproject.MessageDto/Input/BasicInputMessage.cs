using Andromedarproject.MessageDto.Adresses;

namespace Andromedarproject.MessageDto.Input
{
    public class BasicInputMessage
    {
        public Adress Target { get; set; }
        public Adress Sender { get; set; }
        public string AuthString { get; set; }
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
