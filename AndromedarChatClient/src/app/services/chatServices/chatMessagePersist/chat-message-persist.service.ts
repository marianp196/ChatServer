import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatMessagePersistService {

  constructor() { }

  public Push(): Observable<Boolean> {

  }

  public GetByContactID(contactId: string) {

  }
}
