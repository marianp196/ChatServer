import { AuthenticationService } from './services/authentication/authentication.service';
import { EAdressType } from './services/chatServices/chatProtokollDtos/EAdressType';
import { TextMessage } from './services/chatServices/chatProtokollDtos/TextMessage';
import { Adress } from './services/chatServices/chatProtokollDtos/Adress';
import { Component } from '@angular/core';
import { ChatService } from './services/chatServices/chat.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  constructor(private hubConnection: ChatService, private authService: AuthenticationService) {}

  public StartConnection(): void {
    this.authService.Authenticate('User', '').subscribe(x =>
      this.hubConnection.Connect('http://localhost:50481/ChatHub'));

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
