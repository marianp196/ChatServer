import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})

export class ChatService {

  constructor() { }

  private _connection: HubConnection;

  public Connect(url: string): void {
      // http://localhost:50481/ChatHub
      this._connection = new HubConnectionBuilder().withUrl(url).build();
      this._connection.start().then(() => console.log('he'));
  }

  public SendMessage(): void {
    return;
  }
}
