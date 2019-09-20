import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { AuthGuard } from './_guards/auth.guard';
import { CreatepersonComponent } from './createperson/createperson.component';
import { AdminComponent } from './admin/admin.component';
import { ReadLogsComponent } from './admin/readLogs/readLogs.component';
import { UsersComponent } from './admin/users/users.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent },
  {path: 'search', component: SearchComponent, canActivate: [AuthGuard] },
  {path: 'search/:id', component: SearchComponent, canActivate: [AuthGuard] },
  {path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
  {path: 'readlogs', component: ReadLogsComponent, canActivate: [AuthGuard] },
  {path: 'users', component: UsersComponent, canActivate: [AuthGuard] },


  {path: 'createperson', component: CreatepersonComponent, canActivate: [AuthGuard] },


  {path: '**', component: HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
