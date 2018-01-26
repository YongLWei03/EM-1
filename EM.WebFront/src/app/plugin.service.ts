import { Injectable } from '@angular/core';
import { Plugin } from './Plugin';
import { AbstractService } from './abstractservice'
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService} from './message.service'
import { HttpClient, HttpHeaders } from '@angular/common/http';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class PluginService extends AbstractService {
 
  constructor(private http: HttpClient,
    messageService: MessageService) { 
      super(messageService); }

  getPlugins(): Observable<Plugin[]> {
    return this.http.get<Plugin[]>(this.pluginUrl)
    .pipe(
      tap(clients => this.log("fetched plugins")),
      catchError(this.handleError('getPlugins',[]))
    )
  }


}

