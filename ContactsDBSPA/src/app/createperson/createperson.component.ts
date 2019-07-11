import { Component, OnInit } from '@angular/core';
import { CreatePerson } from '../_models/createPerson';
import { CitiesService } from '../_services/cities.service';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { FormControl, Validators } from '@angular/forms';
import { PersonService } from '../_services/person.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-createperson',
  templateUrl: './createperson.component.html',
  styleUrls: ['./createperson.component.css']
})
export class CreatepersonComponent implements OnInit {

  person: CreatePerson;
  cities: string[];

  myControl = new FormControl('', Validators.required);
  name = new FormControl('', Validators.required);
  phone = new FormControl('', Validators.minLength(10));
  email = new FormControl('', Validators.email);
  notes = new FormControl('', Validators.required);
  filteredOptions: Observable<string[]>;


  constructor(private citieservice: CitiesService, private personService: PersonService,
              private alertify: AlertifyService, private router: Router) { }


  ngOnInit() {
    this.getCities();

  }


  save() {
    this.person = new CreatePerson(this.name.value, this.myControl.value, this.notes.value,
      this.phone.value, this.email.value);

    this.personService.CreatePerson(this.person).subscribe(res => this.router.navigate(['/search/' + res]),
     error => this.alertify.error(error.error)
    );

  }

  getCities() {

    this.citieservice.cities().subscribe(
      (res: any) =>  this.cities = res
      , error => console.log(error), () => {
        this.filteredOptions = this.myControl.valueChanges
        .pipe(
          startWith(''),
          map(value => this._filter(value))
        );
      }
      );

  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.cities.filter(option => option.toLowerCase().includes(filterValue));
  }

}
