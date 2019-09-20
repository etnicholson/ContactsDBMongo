import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';


import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  baseUrl = environment.apiUrl + 'log/';

  httpOptions: any;
  constructor(private http: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        Accept: 'application/json',

        Authorization: 'Bearer ' + localStorage.getItem('token'),
      })
    };
   }


   GetLogsWeek() {
    return this.http.request('get', this.baseUrl + 'getlogsweek/', this.httpOptions).pipe(
      map(res =>  res));
    }

    GetLogs(page) {
      return this.http.request('get', this.baseUrl + 'getlogs/' + page, this.httpOptions).pipe(
        map(res =>  res));
      }

    GetLogsByPhone(phone) {
        return this.http.request('get', this.baseUrl + 'getlogsbyphone/' + phone, this.httpOptions).pipe(
          map(res =>  res));
        }

    GetLogsByEmail(email) {
          return this.http.request('get', this.baseUrl + 'getlogsbyemail/' + email, this.httpOptions).pipe(
            map(res =>  res));
    }

    GetMostActive() {
      return this.http.request('get', this.baseUrl + 'getmostactive/', this.httpOptions).pipe(
        map(res =>  res));
      }

}
