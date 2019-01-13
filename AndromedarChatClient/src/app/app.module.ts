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

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ChatMessangerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ChatHubService],
  bootstrap: [AppComponent]
})
export class AppModule { }
