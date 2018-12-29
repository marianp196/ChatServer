import { Input, ChatHubService } from './../chatHub/chatHub.service';
import { Injectable } from '@angular/core';
import { TextMessageInput } from '../chatProtokollDtos/TextMessageInput';

@Injectable({
  providedIn: 'root'
})
export class ChatModelService{

  constructor(private chatHub: ChatHubService) {
    chatHub.RegisterOnIncomingMessage(message => this.push(message));
  }

  private push (message: TextMessageInput): void {

  }
}
