import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { PersonDto } from '../_models/PersonDto';
import { FormControl } from '@angular/forms';
import { PersonService } from '../_services/person.service';
import { Router } from '@angular/router';
import { PhoneService } from '../_services/phone.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  @Input()  person: PersonDto;
  isModalActive = false;
  whatToDelete = '';
  phoneToDetele =  '';
  emailToDetele =  '';
  modalTitle = 'Are you sure want to Delete Person?';
  notes = '' ;
  constructor(private personService: PersonService, private phoneService: PhoneService, private router: Router) {
   }

  ngOnInit() {


  }



  update() {

    this.personService.updatePerson(this.person).subscribe(
      (res: any) =>  {

        this.router.navigate(['/search/' + this.person.id]);



      },  error => {
        console.log(error);

      }

      );


  }

  deleteNumber() {

    this.phoneService.deletePhone(this.phoneToDetele).subscribe(
      (res: any) =>  {

        this.person.phones = this.person.phones.filter(i => i.number !== this.phoneToDetele);
        this.isModalActive = false;

      },  error => {
        console.log(error);

      }

      );
  }

  deletePerson() {

    this.personService.deletePerson(this.person.id).subscribe(
      (res: any) =>  {

        this.router.navigateByUrl('/');


      },  error => {
        console.log(error);

      }

      );
  }

  delete() {

    if (this.whatToDelete === 'Phone') {
      this.deleteNumber();
      } else if (this.whatToDelete === 'Email') {
        console.log('email');
      } else {
        this.deletePerson();
      }




  }
  valueChanged() {
    if (this.person.notes.length !== this.notes.length) {
      return true;
    }
  }

  toggleModal(toDeleteType: string, itemToDelete: string) {
    this.whatToDelete = toDeleteType;
    if (this.whatToDelete === 'Phone') {
    this.phoneToDetele = itemToDelete;
    }

    if (this.whatToDelete === 'Email') {
      this.emailToDetele = itemToDelete;
    }

    this.isModalActive = !this.isModalActive;

  }

}
