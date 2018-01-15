import { Component, OnInit } from '@angular/core';
import { Client } from '../Client';
import { ClientService } from '../client.service'

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {
  
  constructor(private clientService: ClientService) { }
  
  ngOnInit() {
    this.getClients()
  }
  
  clients: Client[];

  getClients(): void {
    this.clientService.getClients().subscribe(clients => this.clients = clients);
  }
}
