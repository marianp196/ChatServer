import { ChatHubService } from './services/chatServices/chatHub/chatHub.service';
import { AuthGuard } from './login/AuthGuard';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { ChatMessangerComponent } from './chat-messanger/chat-messanger.component';
import { FormsModule } from '@angular/forms';
import { ContactListComponent } from './chat-messanger/contact-list/contact-list.component';
import { ContactListItemComponent } from './chat-messanger/contact-list/contact-list-item/contact-list-item.component';
import { TextMessangerComponent } from './chat-messanger/text-messanger/text-messanger.component';
import { TextMessangerContentComponent } from './chat-messanger/text-messanger-content/text-messanger-content.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ChatMessangerComponent,
    ContactListComponent,
    ContactListItemComponent,
    TextMessangerComponent,
    TextMessangerContentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
