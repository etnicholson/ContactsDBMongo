import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLogin } from '../_models/userLogin';
import { AuthService } from '../_services/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @ViewChild('a', {static: false}) loginForm: NgForm;
  hide: boolean;
  user: UserLogin;
  error: string;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.hide = true;
  }

  login() {
    this.user = Object.assign({}, this.loginForm.value);
    this.authService.login(this.user).subscribe(next => {
    }, error => {
      console.log(error);
      this.error = 'Wrong email or password, try again.';
    }, () => {
      this.router.navigate(['/']);
    });

  }

}
