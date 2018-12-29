import { EAdressType } from './../chatServices/chatProtokollDtos/EAdressType';
import { Adress } from './../chatServices/chatProtokollDtos/Adress';
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
      },
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
      },
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
      },
      Name: 'GeileGruppe',
      Prename: null,
      DateOfBirth: null
    };
    resultList.push(contact);
    return new Observable<Contact[]>( o => o.next(resultList));
  }
}
