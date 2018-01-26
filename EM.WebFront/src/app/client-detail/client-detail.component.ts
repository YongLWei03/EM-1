import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import {Router} from '@angular/router';

import { Client } from '../Client';
import { ClientService } from '../client.service'

import { Plugin } from '../Plugin';
import { PluginService } from '../plugin.service'

@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html',
  styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent implements OnInit {
  
  @Input() client: Client;
  
  plugins: Plugin[];
  
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService,
    private pluginService: PluginService,
    private location: Location
  ) {  }
  
  ngOnInit() {
    this.getClient();
    this.getPlugins();
  }
  
  getClient(): void {
    const name = this.route.snapshot.paramMap.get('name');
    if (name) {
      this.clientService.getClient(name).subscribe(client=>{
        this.client = client;
        console.log('client: '+client);
        console.log('detail got one client: '+this.client.Name);
      });
    } else {
      this.client = new Client();
    }
  }
  
  getPlugins(): void {
    this.pluginService.getPlugins().subscribe(plugins => {
      this.plugins = plugins;
      console.log('got plugins');
    });
  }
  
  save(): void {
    console.log('saving.... '+this.client);
    console.log('saving Plugin.Name.... '+this.client.Plugin.FullClassName);
    this.clientService.update(this.client).subscribe(client=>{
      console.log('saved. '+this.client);
      this.router.navigateByUrl('/clients');
    });
  }
  
}
