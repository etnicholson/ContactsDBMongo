import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MaterialModule} from './material.module';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { PersonService } from './_services/person.service';
import { PersonComponent } from './person/person.component';
import { CreatepersonComponent } from './createperson/createperson.component';
import { AdminComponent } from './admin/admin.component';


@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      NavbarComponent,
      HomeComponent,
      SearchComponent,
      PersonComponent,
      CreatepersonComponent,
      AdminComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      MaterialModule,
      FormsModule,
      ReactiveFormsModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
