import { TextMessage } from './../chatProtokollDtos/TextMessage';
import { Adress } from './../chatProtokollDtos/Adress';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})

export class ChatService {

  constructor() { }

  private _connection: HubConnection;

  public Connect(url: string): void {
      this._connection = new HubConnectionBuilder().withUrl(url).build();
      this._connection.start().then(() => console.log('he'));
  }

  public SendMessage(message: TextMessage): void {
    this._connection.send('SendTextMessage', 'User', message);
  }
}
