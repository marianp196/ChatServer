import { ChatMessage } from './../chatService/ChatMessage';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TextContent } from '../chatService/ChatMessage';

@Injectable({
  providedIn: 'root'
})
export class ChatMessagePersistService {

  constructor() { }

  private _storage: ChatMessage[] = [];

  public Push(message: ChatMessage<TextContent>): Observable<Boolean> {
    return new Observable(sub => {
      this._storage.push(message);
      sub.next(true);
    });
  }

  public GetByContactID(contactId: string): Observable<ChatMessage<TextContent>[]> {
    return new Observable(sub => {
      const filtered = this._storage.filter(x => x.PartnerContactId === contactId);
      sub.next(filtered);
      console.log('messageliste ausgeben');
      sub.complete();
    });
  }
}
