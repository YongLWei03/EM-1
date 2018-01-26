import { Injectable } from '@angular/core';
import { Client } from './Client';
import { Plugin } from './Plugin';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService} from './message.service'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestOptions } from '@angular/http';
import { AbstractService } from './abstractservice';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class ClientService extends AbstractService {
  
  constructor(
    private http: HttpClient,
    messageService: MessageService) { super(messageService); }
    
    getClients(): Observable<Client[]> {
      return this.http.get<Client[]>(this.clientUrl)
      .pipe(
        tap(clients => this.log("fetched clients")),
        catchError(this.handleError('getClients',[]))
      )
    }

    getClient(name: string): Observable<Client> {
      const url = `${this.clientUrl}/${name}`;
      return this.http.get<Client>(url).pipe(
        tap(c => this.log(`fetched one client name=${name} ${c.Name}`)),
        catchError(this.handleError<Client>(`getClient client name=${name}`))
      )
    }

    update(client: Client): Observable<string> {
      console.log(client.Plugin.FullClassName);
      return this.http.post<string>(this.clientUrl, client)
      .pipe(
        tap(r=>this.log("updated client "+client.Name)),
        catchError(this.handleError('update',''))
      )
    }

    addClient (client: Client): Observable<Client> {
      return this.http.post<Client>(this.clientUrl, client, httpOptions).pipe(
        tap((client: Client) => this.log('added client w/ name=${client.Name}')),
        catchError(this.handleError<Client>('addClient'))
      );
    }

    delete(client: Client): Observable<Client> {
      const url = `${this.clientUrl}/${client.Name}`;
      return this.http.delete<Client>(url).pipe(
        tap((client: Client) => this.log('deleted client name=${client.Name}')),
        catchError(this.handleError<Client>('delete client'))
      );
    }
    
  }
  