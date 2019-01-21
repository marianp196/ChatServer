import { TextMessageInput } from './chatProtokollDtos/TextMessageInput';
import { TextMessage } from './chatProtokollDtos/TextMessage';
import { Adress } from './chatProtokollDtos/Adress';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class ChatHubService {

  constructor() { }

  private _connection: HubConnection;

  public Connect(url: string): Promise<void> {
      this._connection = new HubConnectionBuilder().withUrl(url).build();
      return this._connection.start();
  }

  public SendMessage(message: TextMessage): Promise<void> {
    if(! this._connection || this._connection.state == HubConnectionState.Disconnected)
      throw new Error('Not Connected to State');
    return this._connection.send('SendTextMessage', message);
  }

  public RegisterOnIncomingMessage(input: (msg: TextMessageInput) => void): void {
      this._connection.on('ReceiveTextMessage', json => {

        //der ganze Bums muss irgendwie einfache gehen
        const textMessageInput = new TextMessageInput();
        textMessageInput.Content = {Text: json.content.text, Attechments: json.content.attechments};
        textMessageInput.ServerId = json.serverId;
        textMessageInput.Sender = {
          Name: json.sender.name,
          Server: json.sender.server,
          AdressType: json.adressType
        } as Adress;
        input(textMessageInput);
      });
  }

  public Disconnect(): Promise<void> {
    if(! this._connection || this._connection.state == HubConnectionState.Disconnected)
      throw new Error('Not Connected to State');
    return this._connection.stop();
  }

  public IsConnected(): boolean {
    console.log(this._connection);
    return this._connection && this._connection.state === HubConnectionState.Connected;
  }
}


