import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PersonService } from '../_services/person.service';
import { PersonDto } from '../_models/PersonDto';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchString: string;
  persons$: Observable<PersonDto[]>;
  person: PersonDto;
  constructor(private personService: PersonService) { }


  ngOnInit() {
      this.person = null;
  }

  search() {
    if(this.searchString.length >= 10){
      this.findByPhone(this.searchString);
      console.log(this.person);

    }
  }

  findByPhone(phone: string) {

    this.personService.findByPhone(phone).subscribe(
      res =>  this.person = res

      );

  }

  findByEmail(email: string){

  }


}
