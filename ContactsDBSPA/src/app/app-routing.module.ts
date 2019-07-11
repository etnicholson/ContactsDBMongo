import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { AuthGuard } from './_guards/auth.guard';
import { CreatepersonComponent } from './createperson/createperson.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent },
  {path: 'search', component: SearchComponent, canActivate: [AuthGuard] },
  {path: 'search/:id', component: SearchComponent, canActivate: [AuthGuard] },

  {path: 'createperson', component: CreatepersonComponent, canActivate: [AuthGuard] },


  {path: '**', component: HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
