import { ChatMessage } from './ChatMessage';
import { Adress } from './../chatProtokollDtos/Adress';
import { Contact } from './../../contacts/contact';
export class ChatModel {
  constructor(private adress: Adress) {
    this._chatMessages = new Array<ChatMessage>();
  }

  private _chatMessages: ChatMessage[];

  public get Adress(): Adress {
    return this.adress;
  }

  public get Messages(): ChatMessage[] {
      return null;
  }

  public PushMessage(chatMessage: ChatMessage): void {
    this.Messages.push(chatMessage);
  }
}
