import { Contact } from './../../contacts/contact';
export class ChatMessage {
  public PartnerContactId: String;
  public Direction: EDirection;
  public Timestamp: Date;
  public Message: String;
}

export enum EDirection {
  In, Out
}
