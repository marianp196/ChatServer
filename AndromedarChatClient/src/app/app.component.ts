import { Adress } from './chatProtokollDtos/Adress';
import { TextMessage } from './chatProtokollDtos/TextMessage';
import { ChatService } from './services/chat.service';
import { Component } from '@angular/core';
import { EAdressType } from './chatProtokollDtos/EAdressType';
import { TextContent, Attechment } from './chatProtokollDtos/TextContent';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  constructor(private hubConnection: ChatService) {}

  public StartConnection(): void {
    this.hubConnection.Connect('http://localhost:50481/ChatHub');
    console.log('hallo');
  }

  public SendMessage(): void {
    let message = new TextMessage();

    let target = new Adress();
    target.AdressType = EAdressType.User;
    target.Name = 'adress1';
    target.Server = 'MyHome';

    let sender = new Adress();
    sender.AdressType = EAdressType.User;
    sender.Name = 'adress2';
    sender.Server = 'MyHome';

    message.Id = '3b98ce4d-b93d-4577-b169-32dbb37e4073';
    message.Sender = sender;
    message.Target = target;
    message.Content = {
      Text: ['Hallo'],
      Attechments: []
    };

    this.hubConnection.SendMessage(message);
  }
}
