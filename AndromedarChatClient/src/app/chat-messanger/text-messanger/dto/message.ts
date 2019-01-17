import { Contact } from './../../../services/contacts/contact';
export class Message {
  public Id: string;
  public Timestamp: Date;
  public Partner: Contact;
  public Text: string;
}
