import { ChatService } from './services/chat.service';
import { Component } from '@angular/core';

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
}
