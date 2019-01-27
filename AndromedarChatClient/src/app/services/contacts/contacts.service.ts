import { Adress } from './../chatServices/chatHub/chatProtokollDtos/Adress';
import { EAdressType } from './../chatServices/chatHub/chatProtokollDtos/EAdressType';

import { Contact, UserContact } from './contact';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor() {
    this.initMoqData();
  }

  private contacts: Contact[] = [];

  public GetContacts(): Observable<Contact[]> {
    return new Observable<Contact[]>( o => o.next(this.contacts));
  }

  public GetContactById(id: string): Observable<Contact> { // Noch auf Observable umabuen
    return new Observable<Contact>(sub => {
      this.GetContacts().subscribe(contacts => {
        const filteredList = contacts.filter(x => x.Id === id);
        const firstOrDefault = filteredList.length > 0 ? filteredList[0] : null;
        sub.next(firstOrDefault);
      });
    });
  }

  public GetContactByAdress(adress: Adress): Observable<Contact> { // Noch auf Observable umabuen
    return new Observable<Contact>(sub => {
      this.GetContacts().subscribe(contacts => {
        const filtered = this.contacts.filter(x => x.Adress.Name === adress.Name
          && x.Adress.Server === adress.Server);
        const firstOrDefault = filtered.length > 0 ? filtered[0] : null;
        sub.next(firstOrDefault);
      });
    });
  }

  public initMoqData(): void {
    const resultList = new Array<UserContact>();
    let contact = this.createMoqUserContact('001', 'Otto');
    resultList.push(contact);

    contact = this.createMoqUserContact('002', 'Manfred');
    resultList.push(contact);

    contact = this.createMoqUserContact('003', 'Hubert');
    resultList.push(contact);
    this.contacts = resultList;
  }

  private createMoqUserContact(id: String, name: String): UserContact {
    const contact = new UserContact;

    contact.Id = id;
    contact.Adress = {
        AdressType: EAdressType.User,
        Name: id,
        Server: 'MyHome'
      } as Adress;
    contact.Name = name;
    contact.Prename = name;
    contact.DateOfBirth = null;

    return contact;
  }
}
