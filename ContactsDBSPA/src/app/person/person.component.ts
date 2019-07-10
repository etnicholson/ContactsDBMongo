import { Component, OnInit, Input } from '@angular/core';
import { PersonDto } from '../_models/PersonDto';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  @Input()  person: PersonDto;
  constructor() { }

  ngOnInit() {
  }

}
