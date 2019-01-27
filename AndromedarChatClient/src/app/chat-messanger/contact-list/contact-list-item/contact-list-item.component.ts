import { Contact, UserContact } from './../../../services/contacts/contact';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-contact-list-item',
  templateUrl: './contact-list-item.component.html',
  styleUrls: ['./contact-list-item.component.scss']
})
export class ContactListItemComponent implements OnInit {

  constructor() { }

  @Input() public Contact: UserContact;

  ngOnInit() {
  }

}
