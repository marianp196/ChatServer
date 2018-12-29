import { Adress } from './../chatProtokollDtos/Adress';
import { Timestamp } from 'rxjs';

export class ChatMessage {
  public Partner: Adress;
  public Timestamp: Date;
  public Text: string;
}
