import { Adress } from './../chatHub/chatProtokollDtos/Adress';
import { IdentityService } from './../../identityInformation/identity.service';
import { MessageResponse } from './MessageResponse';
import { TextMessage } from '../chatHub/chatProtokollDtos/TextMessage';
import { ChatHubService } from './../chatHub/chatHub.service';
import { Injectable } from '@angular/core';
import {IncomingChatMessage } from './IncomingChatMessage';
import { Guid } from "guid-typescript";
import { Observable, Subscribable, Subscriber } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private chatHub: ChatHubService, private identityService: IdentityService ) {
    this.chatHub.RegisterOnIncomingMessage(incoming => {
        let senderAdress = incoming.Sender; // hier müsste natürlich noch die Gruppe berücksichtigt wedren
        let filteredAressHandlers = this.adressHandles.
            filter(a => a.Adress.Name === senderAdress.Name && a.Adress.Server === senderAdress.Server);

        let message = new IncomingChatMessage();
        message.Message = (incoming.Content.Text && incoming.Content.Text.length > 0)
                             ? incoming.Content.Text[0] : '';
        filteredAressHandlers.forEach(handler => handler.Handle(message));
    });
  }

  private adressHandles: AdressHandler[] = [];

  public SendTextMessage(target: Adress, message: String): Observable<MessageResponse> {

    let result = new Observable<MessageResponse>(subscrib => {
      if (!this.IsConnected()) {
        subscrib.error('Not connected');
        subscrib.complete();
        return;
      }

      this.identityService.GetMyAdress().subscribe(adress => {
          this.doSendMessage(subscrib, target, adress.adress, message);
        },
          error => console.log('fehler'));
    });

    return result;
  }

  public RegisterOnAdress(adress: Adress, onIncoming: (msg: IncomingChatMessage) => void) {
    this.adressHandles.push({Adress: adress, Handle: onIncoming});
  }

  public RegisterOnUnknownAdress(onIncoming: (msg: IncomingChatMessage) => void) {

  }

  private doSendMessage(subscrib: Subscriber<MessageResponse>, target: Adress, sender: Adress, text: String) {
    var textMessage = new TextMessage();
    textMessage.Id =  Guid.create().toString();
    textMessage.Sender = sender;
    textMessage.Target = target;
    textMessage.Content = {Attechments: [], Text: [text]};

    this.chatHub.SendMessage(textMessage).then(() => {
      subscrib.next(new MessageResponse());
      subscrib.complete();
    });
  }

  public IsConnected(): boolean {
    return true;
  }
}

class AdressHandler {
  public Adress: Adress;
  public Handle: (msg: IncomingChatMessage) => void;
}
