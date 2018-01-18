import { Injectable } from '@angular/core';
import { Client } from './Client';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService} from './message.service'
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class ClientService {
  private clientUrl = 'http://localhost:9000/api/client'
  
  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }
    
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
      return this.http.post<string>(this.clientUrl, client)
      .pipe(
        tap(r=>this.log("updated client "+client.Name)),
        catchError(this.handleError('update',''))
      )
    }

    addClient (client: Client): Observable<Client> {
      return this.http.post<Client>(this.clientUrl, client, httpOptions).pipe(
        tap((client: Client) => this.log('added client w/ id=${client.Id}')),
        catchError(this.handleError<Client>('addClient'))
      );
    }
    
    private log(message: string) {
      this.messageService.add('ClientService: ' + message);    
    }

    private handleError<T> (operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {
    
        // TODO: send the error to remote logging infrastructure
        console.error(error); // log to console instead
    
        // TODO: better job of transforming error for user consumption
        this.log(`${operation} failed: ${error.message}`);
    
        // Let the app keep running by returning an empty result.
        return of(result as T);
      };
    }
    
  }
  