import { Component, OnInit } from '@angular/core';
import { AdminService } from '../_services/admin.service';
import { Router } from '@angular/router';
import { Angular5Csv } from 'angular5-csv/dist/Angular5-csv';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private adminService: AdminService, private router: Router) { }


  data = [
  ];



  headers = {
    name: 'Name',
    phone: 'Phone1'
  };




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

  getCSV() {
    this.adminService.Csv().subscribe(
      (res: any) =>  {
        this.data = res;
        this.data.unshift(this.headers);



        new Angular5Csv(this.data, 'phones');





      },  error => {
        console.log(error);


      }

      );
  }




}

