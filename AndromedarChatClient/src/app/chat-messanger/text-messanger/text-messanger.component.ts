import { ChatMessage, EDirection } from './../../services/chatServices/chatService/ChatMessage';
import { Message } from '../text-messanger-content/dto/message';
import { ChatService } from './../../services/chatServices/chatService/chat.service';
import { Contact } from './../../services/contacts/contact';

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-text-messanger',
  templateUrl: './text-messanger.component.html',
  styleUrls: ['./text-messanger.component.scss']
})
export class TextMessangerComponent implements OnInit {
  constructor(private chatService: ChatService) {
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

  public Messages: ChatMessage[] = [];
  public _contact: Contact;

  ngOnInit() {
    console.log("init");
  }

  public onSendMessage(msg: String): void {
    this.chatService.SendTextMessage(this.Contact.Adress, msg).subscribe();
    this.Messages.push({
      PartnerContactId: this.Contact.Id,
      Direction: EDirection.Out,
      Timestamp: new Date(),
      Message: msg
    });
  }

  private contactChanged(): void {
    this.Messages = [];
    this.chatService.RegisterOnAdressWithName('messanger', this.Contact.Adress, chatMessage => {
      console.log('message recieved');
      this.Messages.push(chatMessage);
    });
  }
}

