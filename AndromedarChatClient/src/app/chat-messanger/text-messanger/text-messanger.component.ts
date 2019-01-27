import { Observable } from 'rxjs';
import { ChatMessagePersistService } from './../../services/chatServices/chatMessagePersist/chat-message-persist.service';
import { ChatMessage, EDirection, TextContent } from './../../services/chatServices/chatService/ChatMessage';
import { ChatService } from './../../services/chatServices/chatService/chat.service';
import { Contact } from './../../services/contacts/contact';

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-text-messanger',
  templateUrl: './text-messanger.component.html',
  styleUrls: ['./text-messanger.component.scss']
})
export class TextMessangerComponent implements OnInit {
  constructor(private chatService: ChatService, private messagePersist: ChatMessagePersistService) {
  }

  @Input()
  public set Contact(value: Contact) {
    if (!(value  && (!this.Contact || value.Id !== this.Contact.Id))) {
      return;
    }
    this._contact = value;
    this.contactChanged();
  }

  public get Contact(): Contact {
    return this._contact;
  }

  public Messages: ChatMessage<TextContent>[];
  public _contact: Contact;

  public onSendMessage(msg: String): void {
    const message = {
      PartnerContactId: this.Contact.Id,
      Direction: EDirection.Out,
      Timestamp: new Date(),
      Content: {Message: msg}
    };
    this.messagePersist.Push(message).subscribe();
    this.chatService.SendTextMessage(this.Contact.Adress, message.Content).subscribe();
    this.Messages.push(message);
  }

  public onReceiveMessage(msg: ChatMessage<TextContent>) {
    this.Messages.push(msg);
    this.messagePersist.Push(msg).subscribe();
  }

  private contactChanged(): void {
    this.Messages = null;
    this.messagePersist.GetByContactID(this.Contact.Id).subscribe(messages => this.Messages = messages);
    this.chatService.RegisterOnAdressWithName('messanger', this.Contact.Adress,
                                                        this.onReceiveMessage.bind(this));
  }
}

