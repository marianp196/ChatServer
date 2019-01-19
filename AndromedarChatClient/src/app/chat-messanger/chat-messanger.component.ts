import { ChatService } from './../services/chatServices/chatService/chat.service';
import { Message } from './text-messanger/dto/message';
import { ContactsService } from './../services/contacts/contacts.service';
import { Contact } from './../services/contacts/contact';
import { ChatHubService } from './../services/chatServices/chatHub/chatHub.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chat-messanger',
  templateUrl: './chat-messanger.component.html',
  styleUrls: ['./chat-messanger.component.scss']
})
export class ChatMessangerComponent implements OnInit {

  constructor(private chatService: ChatService, private contactsService: ContactsService) { }

  public Contacts: Contact[];
  public SelectedContact: Contact;
  public Messages: Message[] = [];

  ngOnInit() {
    this.contactsService.GetContacts().subscribe(contacts => {
      this.Contacts = contacts;
      this.SelectedContact = this.Contacts ? this.Contacts[0] : null;
      this.initforTest();
    }
    );
  }

  public onSendMessage(message: String): void {
    this.chatService.SendTextMessage(this.SelectedContact.Adress, message)
                        .subscribe(x => console.log(x));
  }

  private initforTest(): void {
    this.Messages.push({
      Id: "001",
      Timestamp: null,
      Partner: this.SelectedContact,
      Text: "Hey"
    });
    this.Messages.push({
      Id: "001",
      Timestamp: null,
      Partner: this.Contacts[1],
      Text: "Hey du"
    });
  }

}
