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
  @Input() public Messages: Message[] = [];
  @Input() public IsGroup: boolean = false;//irwann über Contact regeln

  @Output() public onNewMessage: EventEmitter<String> = new EventEmitter<String>();

  public messsageInput: String = '';

  public isOwn(contact: Contact): boolean {
    return contact.Adress.Name === this.Contact.Adress.Name
          && contact.Adress.Server === this.Contact.Adress.Server;
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
