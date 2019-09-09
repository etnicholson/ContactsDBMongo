import { Component, OnInit } from '@angular/core';
import { AdminService } from '../_services/admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private adminService: AdminService, private router: Router) { }

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

}
