import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @ViewChild('a', {static: false}) loginForm: NgForm;
  hide: boolean;

  constructor() { }

  ngOnInit() {
    this.hide = true;
  }

}
