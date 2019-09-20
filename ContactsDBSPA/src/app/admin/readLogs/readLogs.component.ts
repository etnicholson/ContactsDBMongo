import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/_services/admin.service';
import { LogService } from 'src/app/_services/log.service';
import { Route, Router } from '@angular/router';
import { LogDto } from 'src/app/_models/LogDto';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-readlogs',
  templateUrl: './readLogs.component.html',
  styleUrls: ['./readLogs.component.css']
})
export class ReadLogsComponent implements OnInit {

  logs: LogDto[] = [];
  phone = new FormControl('', Validators.minLength(10));
  email = new FormControl('', Validators.email);


  constructor(private adminService: AdminService, private logService: LogService, private router: Router) { }

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


    this.logService.GetLogs(1).subscribe(
        (res: any) =>  {
          console.log(res);
          this.logs = res;
          console.log(this.logs);

        },  error => {
          console.log(error);

        });


  }

  searchByPhone() {
    this.logService.GetLogsByPhone(this.phone.value).subscribe(
      (res: any) =>  {
        this.logs = res;

      },  error => {
        console.log(error);

      });
  }

  searchByEmail() {
    this.logService.GetLogsByEmail(this.email.value).subscribe(
      (res: any) =>  {
        this.logs = res;
      },  error => {
        console.log(error);
      });
    }




}
