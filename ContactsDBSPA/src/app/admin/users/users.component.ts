import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminService } from 'src/app/_services/admin.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { UserLogin } from 'src/app/_models/userLogin';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  @ViewChild('a', {static: false}) loginForm: NgForm;
  hide: boolean;
  user: UserLogin;
  error: string;

  constructor(private adminService: AdminService,  private router: Router,private authService: AuthService) { }

  ngOnInit() {
    this.adminService.IsAdmin().subscribe(
      (res: any) =>  {

        console.log(res);
        if (res === false) {
          this.router.navigate(['/search/']);
        }



      },  error => {
        console.log(error);
        this.router.navigate(['/search/']);

      }

      );
  }

  register() {
    this.user = Object.assign({}, this.loginForm.value);
    this.authService.register(this.user).subscribe(next => {

      this.loginForm.form.reset();
    }, error => {
      console.log(error);
      this.error = error;
    }, () => {

    });

  }

}
