import { Message } from './../../../chat-messanger/text-messanger-content/dto/message';
import { ContactsService } from './../../contacts/contacts.service';
import { ChatMessage, EDirection } from './ChatMessage';
import { Adress } from './../chatHub/chatProtokollDtos/Adress';
import { IdentityService } from './../../identityInformation/identity.service';
import { MessageResponse } from './MessageResponse';
import { TextMessage } from '../chatHub/chatProtokollDtos/TextMessage';
import { ChatHubService } from './../chatHub/chatHub.service';
import { Injectable } from '@angular/core';
import { Guid } from "guid-typescript";
import { Observable, Subscribable, Subscriber } from 'rxjs';
import { TextMessageInput } from '../chatHub/chatProtokollDtos/TextMessageInput';
import { MessageSenderService } from '../chatHub/message-sender.service';
import { TextContent } from './ChatMessage';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private chatHub: ChatHubService,
                private identityService: IdentityService,
                private contactsService: ContactsService,
                private messageSender: MessageSenderService) {
    this.registerOnIncomingEvent();
  }

  private adressHandles: AdressHandler[] = [];

  public SendTextMessage(target: Adress, message: TextContent): Observable<MessageResponse> {

    return new Observable<MessageResponse>(subscrib => {
      if (!this.IsConnected()) {
        subscrib.error('Not connected');
        subscrib.complete();
        return;
      }

      this.identityService.GetMyAdress().subscribe(adress => {
          this.doSendMessage(subscrib, target, adress.adress, message);
        },
          error => console.log('fehler')
      );
    });
  }

  public RegisterOnAdressWithName(name: String, adress: Adress, onIncoming: (msg: ChatMessage<TextContent>) => void) {
    if (!name) {
      name = Guid.create().toString();
    }
    const index = this.adressHandles.findIndex(x => x.Name === name);
    if (index > -1) {
      this.adressHandles.splice(index, 1);
    }
    this.adressHandles.push({Name: name, Adress: adress, Handle: onIncoming});
  }

  public RegisterOnAdress(adress: Adress, onIncoming: (msg: ChatMessage<TextContent>) => void) {
    this.RegisterOnAdressWithName(Guid.create().toString(), adress, onIncoming);
  }

  public RegisterOnUnknownAdress(onIncoming: (msg: ChatMessage<TextContent>) => void) {

  }

  private doSendMessage(subscrib: Subscriber<MessageResponse>, target: Adress, sender: Adress, content: TextContent) {
    const textMessage = new TextMessage();
    textMessage.Id =  Guid.create().toString();
    textMessage.Sender = sender;
    textMessage.Target = target;
    textMessage.Content = {Attechments: [], Text: [content.Message]};

    this.messageSender.SendMessage(textMessage).subscribe(() => {
      subscrib.next(new MessageResponse());
      subscrib.complete();
    });
  }

  public IsConnected(): boolean {
    return this.chatHub.IsConnected();
  }

  private registerOnIncomingEvent(): void {
    this.chatHub.RegisterOnIncomingMessage(incoming => {
      const senderAdress = incoming.Sender; // hier müsste natürlich noch die Gruppe berücksichtigt wedren

      const filteredAressHandlers = this.adressHandles.
          filter(a => a.Adress.Name === senderAdress.Name && a.Adress.Server === senderAdress.Server);

      this.createMessage(incoming)
        .subscribe(message => filteredAressHandlers.forEach(handler => handler.Handle(message)));
  });
  }

  private createMessage(incoming: TextMessageInput): Observable<ChatMessage<TextContent>> {
    return new Observable<ChatMessage<TextContent>>(sub => {
      const sender = incoming.Sender;
      console.log(sender);
      if (!sender) {
        sub.error('sender nicht gesetzt');
      }
      this.contactsService.GetContactByAdress(sender).subscribe(contact => {
        const message = new ChatMessage<TextContent>();
        message.Direction = EDirection.In;
        message.PartnerContactId = contact.Id;
        message.Content = { Message: (incoming.Content.Text && incoming.Content.Text.length > 0)
                           ? incoming.Content.Text[0] : '' };
        message.Timestamp = new Date(); //hier noch unterscheiden serverzeit.... clientzeit

        sub.next(message);
      });
    });
  }
}

class AdressHandler {
  public Name: String;
  public Adress: Adress;
  public Handle: (msg: ChatMessage<TextContent>) => void;
}
