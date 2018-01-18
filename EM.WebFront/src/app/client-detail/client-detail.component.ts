import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Client } from '../Client';
import { ClientService } from '../client.service'

@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html',
  styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent implements OnInit {
  
  @Input() client: Client;
  
  constructor(
    private route: ActivatedRoute,
    private clientService: ClientService,
    private location: Location
  ) {  }
  
  ngOnInit() {
    this.getClient();
  }

  getClient(): void {
    const name = this.route.snapshot.paramMap.get('name');
    this.clientService.getClient(name).subscribe(client=>{
      this.client = client;
      console.log('client: '+client);
      console.log('detail got one client: '+this.client.Name);
    });
  }

  save(): void {
    console.log('saving....');
  }
  
}
