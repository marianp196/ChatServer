import { Message } from './../../../chat-messanger/text-messanger/dto/message';
import { TextMessage } from './../chatProtokollDtos/TextMessage';
import { Adress } from './../chatProtokollDtos/Adress';
import { ChatHubService } from './../chatHub/chatHub.service';
import { Injectable } from '@angular/core';
import {IncomingChatMessage } from './IncomingChatMessage';
import { Guid } from "guid-typescript";

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  constructor(private chatHub: ChatHubService) { }

  public SendTextMessage(target: Adress, message: String): void {
    if (!this.IsConnected()) {
      return; //hier Exception
    }

    var textMessage = new TextMessage();
    textMessage.Id =  Guid.create().toString();
    textMessage.Sender = {};
    textMessage.Target = target;
    textMessage.Content = {Attechments: [], Text: [message]};

    this.chatHub.SendMessage(textMessage);
  }

  public RegisterOnAdress(adress: Adress, onIncoming: (msg: IncomingChatMessage) => void) {

  }

  public RegisterOnUnknownAdress(onIncoming: (msg: IncomingChatMessage) => void) {

  }

  public IsConnected(): boolean {

  }
}
