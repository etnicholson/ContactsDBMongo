import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { PersonDto } from '../_models/PersonDto';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  @Input()  person: PersonDto;
  notes = '' ;
  constructor() {
   }

  ngOnInit() {

    console.log('hiiiii');

  }


  valueChanged() {
    if (this.person.notes.length !== this.notes.length) {
      return true;
    }
  }

}
