/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CreatepersonComponent } from './createperson.component';

describe('CreatepersonComponent', () => {
  let component: CreatepersonComponent;
  let fixture: ComponentFixture<CreatepersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatepersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatepersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
