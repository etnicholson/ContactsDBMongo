import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CitiesService {

  baseUrl = environment.apiUrl + 'Cities/';

  httpOptions: any;
  constructor(private http: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        Accept: 'application/json',

        Authorization: 'Bearer ' + localStorage.getItem('token'),
      })
    };
   }

   cities() {

    return this.http.request('get', this.baseUrl + 'cities/', this.httpOptions).pipe(
      map(res =>  res));

    }


}
