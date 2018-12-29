import { Adress } from './../chatProtokollDtos/Adress';
import { Timestamp } from 'rxjs';

export class ChatMessage {
  public MessageType: EMessageType;
  public Partner: Adress;
  public Group: Adress;
  public Timestamp: Date;
  public Text: string;
}

export enum EMessageType {
  User,
  Group
}
