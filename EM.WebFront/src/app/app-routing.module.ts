import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientsComponent } from './clients/clients.component'
import { NewClientComponent } from './new-client/new-client.component'
import { ClientDetailComponent} from './client-detail/client-detail.component'

const routes: Routes = [
  {path: 'clients', component: ClientsComponent},
  {path: 'newclient', component: NewClientComponent},
  {path: '', redirectTo: '/newclient', pathMatch: 'full' },
  {path: 'detail/:name', component: ClientDetailComponent}
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ] 
})
export class AppRoutingModule { 
  
}
