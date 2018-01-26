import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ClientsComponent } from './clients/clients.component';
import { ClientService } from './client.service';
import { PluginService } from './plugin.service';
import { MessageService } from './message.service';
import { MessagesComponent } from './messages/messages.component';
import { ClientDetailComponent } from './client-detail/client-detail.component';
import { AppRoutingModule } from './/app-routing.module';
import { NewClientComponent } from './new-client/new-client.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientsComponent,
    MessagesComponent,
    ClientDetailComponent,
    NewClientComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [ClientService, PluginService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
