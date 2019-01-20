import { Adress } from './../chatServices/chatHub/chatProtokollDtos/Adress';
import { EAdressType } from './../chatServices/chatHub/chatProtokollDtos/EAdressType';

import { Contact } from './contact';
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
    let resultList = new Array<Contact>();
    let contact = {
      Id: '001',
      Adress : {
        AdressType: EAdressType.User,
        Name: '001',
        Server: 'MyHome'
      } as Adress,
      Name: 'Otto',
      Prename: 'Otto',
      DateOfBirth: null
    };
    resultList.push(contact);
    contact = {
      Id: '002',
      Adress : {
        AdressType: EAdressType.User,
        Name: '002',
        Server: 'MyHome'
      } as Adress,
      Name: 'Manfred',
      Prename: 'Manfred',
      DateOfBirth: null
    };
    resultList.push(contact);

    contact = {
      Id: '003',
      Adress : {
        AdressType: EAdressType.User,
        Name: '003',
        Server: 'MyHome'
      } as Adress,
      Name: 'Helmut',
      Prename: 'Helmut',
      DateOfBirth: null
    };
    resultList.push(contact);
    this.contacts = resultList;
  }
}
