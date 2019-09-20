import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../../environments/environment';
import { User } from '../_models/user';
import { UserLogin } from '../_models/userLogin';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;
  httpOptions: any;

  constructor(private http: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        Accept: 'application/json',

        Authorization: 'Bearer ' + localStorage.getItem('token'),
      })
    };
  }



  login(model: any) {
    return this.http.post(this.baseUrl + 'Auth/login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {


          console.log(user); 
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', user.email);

        }
      })
    );
  }



  register(user: UserLogin) {
    return this.http.post(this.baseUrl + 'Auth/register', user , this.httpOptions);
  }

  delete(email) {
    return this.http.request('post', this.baseUrl + 'Auth/delete/' + email, this.httpOptions);
  }
  retriveUsers() {
    return this.http.get(this.baseUrl + 'Auth/retriveallusers', this.httpOptions);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

}
