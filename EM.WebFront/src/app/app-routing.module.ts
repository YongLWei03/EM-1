import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientsComponent } from './clients/clients.component'
import { NewClientComponent } from './new-client/new-client.component'

const routes: Routes = [
  {path: 'clients', component: ClientsComponent},
  {path: 'newclient', component: NewClientComponent},
  { path: '', redirectTo: '/newclient', pathMatch: 'full' },
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ] 
})
export class AppRoutingModule { 
  
}
