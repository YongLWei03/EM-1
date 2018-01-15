import { Injectable } from '@angular/core';
import { Client } from './Client';
import { CLIENTS } from './mock-clients';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService} from './message.service'
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable()
export class ClientService {
  private clientUrl = 'http://localhost:9000/api/values'
  
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

    update(client: Client): Observable<string> {
      return this.http.post<string>(this.clientUrl, client)
      .pipe(
        tap(r=>this.log("updated client "+client.Name)),
        catchError(this.handleError('update',''))
      )
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
  