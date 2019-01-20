import { ChatMessage, EDirection } from './../../services/chatServices/chatService/ChatMessage';
import { Contact } from './../../services/contacts/contact';
import { Message } from './dto/message';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-text-messanger-content',
  templateUrl: './text-messanger-content.component.html',
  styleUrls: ['./text-messanger-content.component.scss']
})
export class TextMessangerContentComponent implements OnInit {
  constructor() { }

  @Input() public Contact: Contact;
  @Input() public Messages: ChatMessage[] = [];
  @Input() public IsGroup: boolean = false;//irwann über Contact regeln

  @Output() public onNewMessage: EventEmitter<String> = new EventEmitter<String>();

  public messsageInput: String = '';

  public isOwn(message: ChatMessage): boolean {
    return message.Direction === EDirection.In;
  }

  public onSendMessage(): void {
    if (this.messsageInput === '') {
      return;
    }
    this.onNewMessage.emit(this.messsageInput);
    this.messsageInput = '';
  }

  ngOnInit() {
  }

}
