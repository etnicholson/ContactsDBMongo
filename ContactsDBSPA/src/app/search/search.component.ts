import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PersonService } from '../_services/person.service';
import { PersonDto } from '../_models/PersonDto';
import { Observable } from 'rxjs';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchString: string;
  persons$: Observable<PersonDto[]>;
  person: PersonDto;
  constructor(private personService: PersonService, private alertify: AlertifyService) { }


  ngOnInit() {
      this.person = null;
  }

  search() {
    if (this.searchString.length >= 10) {
      if (this.searchString.includes('@')){
        this.findByEmail(this.searchString);
      } else {
        this.findByPhone(this.searchString);
      }



    }
  }

  findByPhone(phone: string) {

    this.personService.findByPhone(phone).subscribe(
      (res: any) =>  this.person = res,  error => {
        this.alertify.error('Phone not on file');
        this.person = null;

      }

      );

  }

  findByEmail(email: string) {
    this.personService.findByEmail(email).subscribe(
      (res: any) =>  this.person = res,  error =>{
        this.alertify.error('Email not on file');
        this.person = null;
     }

      );
  }


}
