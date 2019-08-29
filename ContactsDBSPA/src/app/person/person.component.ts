import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { PersonDto } from '../_models/PersonDto';
import { FormControl } from '@angular/forms';
import { PersonService } from '../_services/person.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  @Input()  person: PersonDto;
  isModalActive = false;
  notes = '' ;
  constructor(private personService: PersonService, private router: Router) {
   }

  ngOnInit() {


  }

  delete() {

    this.personService.deletePerson(this.person.id).subscribe(
      (res: any) =>  {
        console.log('hi');
        this.router.navigateByUrl('/');


      },  error => {
        console.log(error);

      }

      );


  }
  valueChanged() {
    if (this.person.notes.length !== this.notes.length) {
      return true;
    }
  }

  toggleModal() {
    this.isModalActive = !this.isModalActive;
  }

}
