import { Injectable } from '@angular/core';
import { Client } from './Client';
import { CLIENTS } from './mock-clients';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { MessageService} from './message.service'

@Injectable()
export class ClientService {

  constructor(private messageService: MessageService) { }

  getClients(): Observable<Client[]> {
    this.messageService.add('ClientService: fetched clients');
    return of(CLIENTS);
  }

}
