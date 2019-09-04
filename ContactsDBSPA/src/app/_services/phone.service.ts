import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';


import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  baseUrl = environment.apiUrl + 'Phone/';

  httpOptions: any;
  constructor(private http: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        Accept: 'application/json',

        Authorization: 'Bearer ' + localStorage.getItem('token'),
      })
    };
   }

   deletePhone(number) {

    return this.http.request('post', this.baseUrl + 'deletephone/' +  number, this.httpOptions).pipe(
      map(res =>  res));

  }

  CreatePhone(phone) {

    return this.http.post(this.baseUrl + 'createphone/', phone, this.httpOptions).pipe(
      map(res =>  res));

  }
}
