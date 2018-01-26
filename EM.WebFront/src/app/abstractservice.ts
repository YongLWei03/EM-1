import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { MessageService} from './message.service'
import { of } from 'rxjs/observable/of';

@Injectable()
export class AbstractService {
    private baseUrl: string = 'http://localhost:9000/api';
    protected pluginUrl = this.baseUrl+'/plugin'
    protected clientUrl = this.baseUrl+'/client'

    constructor(
        private messageService: MessageService) { }
      
    protected log(message: string) {
        this.messageService.add('ClientService: ' + message);    
      }

    protected handleError<T> (operation = 'operation', result?: T) {
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