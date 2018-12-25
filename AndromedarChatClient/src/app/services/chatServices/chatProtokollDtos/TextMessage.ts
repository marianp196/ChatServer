import { TextContent } from './TextContent';
import { Adress } from './Adress';

export class TextMessage {
  public Id: string;

  public Target: Adress;
  public Sender: Adress;

  public Content: TextContent;
}
