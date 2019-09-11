import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';


import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  baseUrl = environment.apiUrl + 'admin/';

  httpOptions: any;
  constructor(private http: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        Accept: 'application/json',

        Authorization: 'Bearer ' + localStorage.getItem('token'),
      })
    };
   }

   IsAdmin() {

    return this.http.request<boolean>('get', this.baseUrl + 'isadmin/', this.httpOptions).pipe(
      map(res =>  res));
    }

   Csv() {
      return this.http.request('get', this.baseUrl + 'csv/', this.httpOptions).pipe(
        map(res =>  res));
      }

}
