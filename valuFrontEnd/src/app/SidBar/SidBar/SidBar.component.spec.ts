/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SidBarComponent } from './SidBar.component';

describe('SidBarComponent', () => {
  let component: SidBarComponent;
  let fixture: ComponentFixture<SidBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SidBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SidBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
