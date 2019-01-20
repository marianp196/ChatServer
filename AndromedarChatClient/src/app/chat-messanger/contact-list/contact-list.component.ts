import { Contact } from './../../services/contacts/contact';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss']
})
export class ContactListComponent implements OnInit {

  constructor() { }

  @Input()
  public Contacts: Contact[] = [];

  //Item Two way DataBinding
  @Input()
  public set Item(value: Contact) {
    this._item = value;
    this.ItemChange.emit(value);
  }

  @Output()
  public ItemChange: EventEmitter<Contact> = new EventEmitter<Contact>();
  private _item: Contact;

  ngOnInit() {
  }

  private clickListItem(contact: Contact): void {
    console.log(contact.Name);
    this.Item = contact;
  }

}
