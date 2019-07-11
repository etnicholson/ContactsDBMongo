import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';


import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { PersonDto } from '../_models/PersonDto';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseUrl = environment.apiUrl + 'Person/';

  httpOptions: any;
  constructor(private http: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        Accept: 'application/json',

        Authorization: 'Bearer ' + localStorage.getItem('token'),
      })
    };
   }

   findByPhone(phone) {

    return this.http.request<PersonDto>('get', this.baseUrl + 'findbyphone/' + phone, this.httpOptions).pipe(
      map(res =>  res));

    }


    findByEmail(phone) {

      return this.http.request<PersonDto>('get', this.baseUrl + 'findbyemail/' + phone, this.httpOptions).pipe(
        map(res =>  res));

      }

      CreatePerson(person) {

        return this.http.post(this.baseUrl + 'createperson/', person, this.httpOptions).pipe(
          map(res =>  res));

        }



}
