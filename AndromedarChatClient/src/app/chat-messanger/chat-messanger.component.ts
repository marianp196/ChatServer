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

  constructor(private hub: ChatHubService, private contactsService: ContactsService) { }

  public Contacts: Contact[];
  public SelectedContact: Contact;

  ngOnInit() {
    this.contactsService.GetContacts().subscribe(contacts => {
      this.Contacts = contacts;
      this.SelectedContact = this.Contacts ? this.Contacts[0] : null;
    });
  }

}
