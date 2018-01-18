import { Component, OnInit } from '@angular/core';
import { Client } from '../Client';
import { ClientService } from '../client.service'
import {AnonymousSubscription} from "rxjs/Subscription";
import {Observable} from "rxjs/Rx";

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  selectedClient: Client;
  
  constructor(private clientService: ClientService) { }
  
  ngOnInit() {
    this.getClients()
    this.refreshClients()
  }
  
  clients: Client[];
  private timerSubscription: AnonymousSubscription;

  update(client: Client): void {
    console.log("will update");

    this.clientService.update(client).subscribe();
  }

  getClients(): void {
    this.clientService.getClients().subscribe(clients => this.clients = clients);
  }

  refreshClients(): void {
    this.clientService.getClients().subscribe(clients => {
      console.log('got new clients');
      this.clients = clients;
      this.subscribeTo();
    });
    
  }

  subscribeTo(): void {
    this.timerSubscription = Observable.timer(5000).first().subscribe(() => this.refreshClients());
  }

  onSelect(client: Client): void {
    this.selectedClient = client;
    console.log("hello world "+ this.selectedClient);
  }

  add(Name: string): void {
    Name = Name.trim();
    if (!Name) { return; }
    this.clientService.addClient({ Name } as Client)
      .subscribe(client => {
        this.clients.push(client);
      });
  }
}
