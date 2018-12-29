import { Timestamp } from 'rxjs';
import { ChatMessage, EMessageType } from './ChatMessage';
import { TextContent } from './../chatProtokollDtos/TextContent';
import { Adress } from './../chatProtokollDtos/Adress';
import { ChatHubService } from './../chatHub/chatHub.service';
import { Injectable } from '@angular/core';
import { TextMessageInput } from '../chatProtokollDtos/TextMessageInput';
import { TextMessage } from '../chatProtokollDtos/TextMessage';
import {Guid} from 'guid-typescript';
import { EAdressType } from '../chatProtokollDtos/EAdressType';

@Injectable({
  providedIn: 'root'
})
export class ChatModelService{

  constructor(private chatHub: ChatHubService) {
    chatHub.RegisterOnIncomingMessage(message => this.pushIncomingMessage(message));
  }

  private unknownMessageDelegate: (message: ChatMessage) => void;
  private messageDelegates: MessageDelegate[] = new Array<MessageDelegate>();

  public Push (target: Adress, content: string): void {
    let message = new TextMessage();
    message.Id = Guid.create().toString();
    message.Sender = this.getSenderAdress();
    message.Target = target;
    message.Content = { Text: [content], Attechments: []};
    this.chatHub.SendMessage(message);
  }

  public RegisterOnAdress(adress: Adress, func: (message: ChatMessage) => void): void {
    let funcDto = {
      PartnerAdress: adress,
      Func: func
    };
    this.messageDelegates.push(funcDto);
  }

  public RegisterOnUnknownAdress(func: (message: ChatMessage) => void): void {
    this.unknownMessageDelegate = func;
  }

  private pushIncomingMessage(message: TextMessageInput): void {
    let chatMessage = {
      MessageType: message.SenderGroup ? EMessageType.Group : EMessageType.User,
      Partner: message.Sender,
      Group: message.SenderGroup,
      Text: message.Content.Text[0],
      Timestamp: this.getUtc()
    };

    let i = 0;
    this.messageDelegates.forEach(mesDel => {
      let sender = chatMessage.MessageType === EMessageType.User ? chatMessage.Partner : chatMessage.Group;
      if (mesDel.PartnerAdress.Equals(sender)) {
        mesDel.Func(chatMessage);
        i++;
      }
    });

    if (i === 0 && this.unknownMessageDelegate) {
      this.unknownMessageDelegate(chatMessage);
    }
  }

  private getSenderAdress(): Adress {
    return {
      Name: 'adress1',
      Server: 'MyHome',
      AdressType: EAdressType.User
    } as Adress;
  }

  private getUtc(): Date {
    var now = new Date;
    var utc_timestamp = Date.UTC(now.getUTCFullYear(),now.getUTCMonth(), now.getUTCDate() ,
      now.getUTCHours(), now.getUTCMinutes(), now.getUTCSeconds(), now.getUTCMilliseconds());
    return new Date(utc_timestamp);
  }
}

class MessageDelegate {
  public PartnerAdress: Adress;
  public Func: (message: ChatMessage) => void;
}
