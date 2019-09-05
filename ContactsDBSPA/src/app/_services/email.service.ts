import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';


import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  baseUrl = environment.apiUrl + 'email/';

  httpOptions: any;
  constructor(private http: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        Accept: 'application/json',

        Authorization: 'Bearer ' + localStorage.getItem('token'),
      })
    };
   }

   deleteEmail(email) {

    return this.http.request('post', this.baseUrl + 'deleteemail/' +  email, this.httpOptions).pipe(
      map(res =>  res));

  }

  CreateEmail(email) {


    return this.http.post(this.baseUrl + 'createemail/', email, this.httpOptions).pipe(
      map(res =>  res));

  }




}
