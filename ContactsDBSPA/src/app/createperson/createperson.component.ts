import { Component, OnInit } from '@angular/core';
import { CreatePerson } from '../_models/createPerson';

@Component({
  selector: 'app-createperson',
  templateUrl: './createperson.component.html',
  styleUrls: ['./createperson.component.css']
})
export class CreatepersonComponent implements OnInit {

  person: CreatePerson;
  constructor() { }

  ngOnInit() {
  }


  save(){
    console.log(this.person);
  }

}
