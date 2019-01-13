import { ChatMessage } from './ChatMessage';
import { Contact } from './../../contacts/contact';
export class ChatModel {
  constructor(public Contact: Contact, public ChatMessages: ChatMessage[]) {

  }

  public AddMessage(message: ChatMessage) {
    this.ChatMessages.push(message);
  }
}
