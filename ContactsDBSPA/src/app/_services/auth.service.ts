import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../../environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;

  constructor(private http: HttpClient) {}



  login(model: any) {
    return this.http.post(this.baseUrl + 'Auth/login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {

          //localStorage.setItem('token', response.access_token);

          console.log(user); 
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', user.email);
          //this.decodedToken = this.jwtHelper.decodeToken(user.token);
          //console.log(this.decodedToken);
        }
      })
    );
  }


  /*
  register(user: UserRegister) {
    return this.http.post(this.baseUrl + 'register', user);
  }
  */
 
  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }


}
