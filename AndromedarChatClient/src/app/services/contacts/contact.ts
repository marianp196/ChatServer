import { Adress } from './../chatServices/chatHub/chatProtokollDtos/Adress';

export class Contact {
  Id: String;
  Adress: Adress;
}

export class UserContact extends Contact {
  Name: String;
  Prename: String;
  DateOfBirth: Date;
}
