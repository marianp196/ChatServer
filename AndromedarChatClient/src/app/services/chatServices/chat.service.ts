import { TextMessage } from './chatProtokollDtos/TextMessage';
import { Adress } from './chatProtokollDtos/Adress';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@aspnet/signalr';

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

  public SendMessage(message: TextMessage): Boolean {
    if (this._connection.state === HubConnectionState.Disconnected) {
      return false;
    }
    this._connection.send('SendTextMessage', 'User', message);

    return true;
  }
}
