import { TextContent } from './TextContent';
import { Adress } from './Adress';
import { Address } from 'cluster';
export class TextMessageInput {
  public ServerId: string;

  public Sender: Adress;
  public SenderGroup: Address;
  public Target: Adress;

  public Content: TextContent;
}
