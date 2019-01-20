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
  constructor(chatService: ChatService) {

  }

  @Input() public Contact: Contact;
  public Messages: Message[] = [];

  ngOnInit() {
    console.log("init");
  }

  public onSendMessage(msg: String) {
    console.log(msg + 'Hure');
  }
}

