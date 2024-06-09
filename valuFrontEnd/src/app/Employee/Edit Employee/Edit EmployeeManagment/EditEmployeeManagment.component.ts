import { Component, OnInit, Inject } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { DatePipe } from '@angular/common';

import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
} from '@angular/material/dialog';

import { IDeparment } from 'src/app/Models/IDeparment';
import { DepartmentService } from 'src/app/Service/DepartmentService.service';
import { EmployeeServicesService } from 'src/app/Service/EmployeeServices.service';
import { egyptianMobileNumberValidator } from 'src/app/Vaildator/MobileNumber';
@Component({
  selector: 'app-EditTaskManagment',
  templateUrl: './EditEmployeeManagment.component.html',
  styleUrls: ['./EditEmployeeManagment.component.scss'],
})
export class EditEmployeeManagment implements OnInit {
  myForm: FormGroup;
  departmentList: IDeparment[];
  form: any;
  startDate: string;
  selectedOption: string = 'Select Department Name';
  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<EditEmployeeManagment>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private  DepartmentServiceManagement: DepartmentService,
    private datePipe: DatePipe,
    private EmployeeManagmentService: EmployeeServicesService
  ) {
    this.form = this.data.message;
    const dateFormat = 'yyyy-MM-dd';
    this.form.hireDate = this.datePipe.transform(this.form.hireDate, dateFormat);
    this.myForm = this.fb.group({
      id: [this.form.id],
      departmentID:[this.form.departmentID],
      name: [this.form.name, Validators.required],
      hireDate: [this.form.hireDate, Validators.required],
      identification: [this.form.identification, Validators.required],
      phone: [this.form.phone, Validators.pattern(/^\d{10}$/)],
      mobileNumber: [this.form.mobileNumber, [Validators.required, egyptianMobileNumberValidator()]],
      position: [this.form.position, Validators.required],
    });
  }

  ngOnInit() {
    this.DepartmentServiceManagement.GetRefershLoadUsers().subscribe((user) => {
      this.GetAllDepartmentsService();
    });
    this.GetAllDepartmentsService();
  }
  EditEmployee()
  {
    if (this.myForm.valid) {
console.log(this.myForm.value);
      const formData = new FormData();
      formData.append('id', this.myForm.get('id').value);
      formData.append('departmentID', this.myForm.get('departmentID').value);
      formData.append('name', this.myForm.get('name').value);
      formData.append('identification', this.myForm.get('identification').value);
      formData.append('hireDate', this.myForm.get('hireDate').value);
      formData.append('phone', this.myForm.get('phone').value);
      formData.append('mobileNumber', this.myForm.get('mobileNumber').value);
      formData.append('position', this.myForm.get('position').value);
      this.EmployeeManagmentService.EditEmployeeservice(formData).subscribe(res =>{
        this.CloseFOrm();
      },err =>{
        console.log(err);
      })
    } else {
      console.log('Form is invalid');
    }
  }
  GetAllDepartmentsService() {
    this.DepartmentServiceManagement.GetAllDepartmentsService().subscribe(
      (data) => {
        this.departmentList = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  CloseFOrm(): void {
    this.dialogRef.close();
  }
}
