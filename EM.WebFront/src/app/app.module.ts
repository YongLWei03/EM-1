import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { ClientsComponent } from './clients/clients.component';
import { ClientService } from './client.service';
import { MessageService } from './message.service';
import { MessagesComponent } from './messages/messages.component';


@NgModule({
  declarations: [
    AppComponent,
    ClientsComponent,
    MessagesComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [ClientService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
