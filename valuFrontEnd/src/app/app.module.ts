import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BodyComponent } from './Body/Body/Body.component';
import { SidBarComponent } from './SidBar/SidBar/SidBar.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { DatePipe } from '@angular/common';

import { AddEmployeeManagment } from './Employee/Add Employee/Add EmployeeManagment/AddEmployeeManagment.component';
import { EditEmployeeManagment } from './Employee/Edit Employee/Edit EmployeeManagment/EditEmployeeManagment.component';
import { DepartmentmanagmentComponent } from './Department/DepartmentManagment/Departmentmanagment/Departmentmanagment.component';
import { AddDepartmentManagementComponent } from './Department/AddDepartmentManagement/AddDepartmentManagement/AddDepartmentManagement.component';
import { EditDeparmentManagmentComponent } from './Department/EditDeparmentManagement/EditDeparmentManagment/EditDeparmentManagment.component';
import { EmployeeListManagment } from './Employee/EmployeeList/EmployeeListManagment.component.htmlListManagment/EmployeeListManagment.component';


@NgModule({
  declarations: [
    AppComponent,
    BodyComponent,
    SidBarComponent,
    DepartmentmanagmentComponent,
    AddDepartmentManagementComponent,
    EditDeparmentManagmentComponent,
    EmployeeListManagment,
    AddEmployeeManagment,
    EditEmployeeManagment
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDialogModule,
    MatInputModule ,
    MatDatepickerModule
    
  ],
  providers: [
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}},
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
