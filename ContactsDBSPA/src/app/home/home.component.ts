import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {

    const loggedin = this.check();

    if (loggedin) {
      this.router.navigate(['/search']);
    } else {
      this.router.navigate(['/login']);
    }
  }


  check() {
    const token = localStorage.getItem('token');
    return !!token;
  }

}
