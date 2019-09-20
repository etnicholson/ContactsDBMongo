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
  users = [];
  isModalActive = false;
  whatToDelete = '';


  constructor(private adminService: AdminService,  private router: Router, private authService: AuthService) { }

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

    this.authService.retriveUsers().subscribe((res: any) => {

      this.users = res;
      }, error => {
        console.log(error);
        this.error = error;
      }, () => {
  
      });

  }

  register() {
    this.user = Object.assign({}, this.loginForm.value);
    this.authService.register(this.user).subscribe(next => {
      this.users.push(this.user.email);
      this.loginForm.form.reset();
    }, error => {
      console.log(error);
      this.error = error;
    }, () => {

    });

  }


  toggleModal(toDelete: string) {

    this.whatToDelete = toDelete;

    this.isModalActive = !this.isModalActive;
  }

  delete() {
    this.isModalActive = !this.isModalActive;



    this.authService.delete(this.whatToDelete).subscribe((res: any) => {
     console.log(this.whatToDelete);
      this.users = this.users.filter(i => i !== this.whatToDelete);
      }, error => {
        console.log(error);
        this.error = error;
      }, () => {
  
      });

  }

}
