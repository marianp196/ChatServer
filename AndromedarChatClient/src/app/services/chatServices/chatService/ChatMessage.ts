import { Contact } from './../../contacts/contact';

export class TextContent {
  public Message: String;
  //Attechments
}

export class ChatMessage<TContent> {
  public PartnerContactId: String;
  public Direction: EDirection;
  public Timestamp: Date;
  public Content: TContent;
}

export enum EDirection {
  In, Out
}
