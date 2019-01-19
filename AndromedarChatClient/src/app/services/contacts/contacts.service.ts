import { Adress } from './../chatServices/chatHub/chatProtokollDtos/Adress';
import { EAdressType } from './../chatServices/chatHub/chatProtokollDtos/EAdressType';

import { Contact } from './contact';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor() { }

  public GetContacts(): Observable<Contact[]> {
    let resultList = new Array<Contact>();
    let contact = {
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
    console.log('test');
    return new Observable<Contact[]>( o => o.next(resultList));
  }
}
