import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchString: string;
  constructor() { }

  ngOnInit() {
  }

  search() {
    if(this.searchString.length >= 10){


    }

    
  }

  findByPhone(phone: string){

  }

  findByEmail(email: string){

  }


}
