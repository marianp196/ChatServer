import { TextContent } from './TextContent';
import { Adress } from './Adress';
export class TextMessageInput {
  public ServerId: string;

  public Sender: Adress;
  public SenderGroup: Adress;
  public Target: Adress;

  public Content: TextContent;
}
