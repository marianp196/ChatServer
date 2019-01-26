import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageSenderService {

  constructor(private http: HttpClient) { }

  public SendMessage(message: TextMessage): Observable<any> {//Hier müsste noch das Messageresult entgegen genommen werden
    //Prüfen ob Connection da ist..wenn nicht dann fehler oder versuchen connection aufzubauen
    return this.http.post('http://localhost:50481/api/TextMessageInput', message, {withCredentials: true});
  }
}
