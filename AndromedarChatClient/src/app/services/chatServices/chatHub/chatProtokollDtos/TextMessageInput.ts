import { TextContent } from './TextContent';
import { Adress } from './Adress';
export class TextMessageInput {
  public serverId: string;

  public sender: Adress;
  public tenderGroup: Adress;
  public target: Adress;

  public content: TextContent;
}
