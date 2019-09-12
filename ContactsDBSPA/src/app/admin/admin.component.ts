import { Component, OnInit } from '@angular/core';
import { AdminService } from '../_services/admin.service';
import { Router } from '@angular/router';
import { Angular5Csv } from 'angular5-csv/dist/Angular5-csv';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { LogService } from '../_services/log.service';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  dates = [
  ];


  view: any[] = [700, 400];
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = false;
  showXAxisLabel = true;
  xAxisLabel = 'Day';
  showYAxisLabel = true;
  yAxisLabel = 'Logs';

  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
  };




  constructor(private adminService: AdminService, private logService: LogService , private router: Router) { 
    this.logService.GetLogsWeek().subscribe(
      (res: any) =>  {

        this.dates = res;


      },  error => {
        console.log(error);

      });

  }


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

