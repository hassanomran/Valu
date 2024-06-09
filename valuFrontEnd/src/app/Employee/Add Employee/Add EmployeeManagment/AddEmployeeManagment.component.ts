import { IDeparment } from '../../../Models/IDeparment';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import { DepartmentService } from 'src/app/Service/DepartmentService.service';
import { EmployeeServicesService } from 'src/app/Service/EmployeeServices.service';
import { egyptianMobileNumberValidator } from 'src/app/Vaildator/MobileNumber';
@Component({
  selector: 'app-AddTaskManagment',
  templateUrl: './AddEmployeeManagment.component.html',
  styleUrls: ['./AddEmployeeManagment.component.scss']
})
export class AddEmployeeManagment implements OnInit {
  myForm: FormGroup;
  form : any;
  departmentList: IDeparment[];
  selectedOption: string = 'Select Department Name';

  constructor(private fb: FormBuilder,  public dialogRef: MatDialogRef<AddEmployeeManagment>,private EmployeeManagmentService: EmployeeServicesService,private DepartmentServiceManagement: DepartmentService) 
  { 
    this.myForm = this.fb.group({
      name: ['', Validators.required],
      departmentID : ['', Validators.required],
      hireDate: ['', Validators.required],
      identification: ['', Validators.required],
      phone: ['', Validators.pattern(/^\d{10}$/)],
      mobileNumber: ['', [Validators.required, egyptianMobileNumberValidator()]],
      position: ['', Validators.required],
    });
    //console.log(this.myForm.value);
  }

  ngOnInit() {
    this.DepartmentServiceManagement.GetRefershLoadUsers().subscribe(user =>{
      this.GetAllDepartmentService();
    });
    this.GetAllDepartmentService();
  }
  GetAllDepartmentService()
  {
    this.DepartmentServiceManagement.GetAllDepartmentsService().subscribe(
      data => {
        this.departmentList = data;
      },
      error => {
        console.log(error);
      }
    );  
  }
  AddNewEmployee(): void {
    if (this.myForm.valid) {
      const formData = new FormData();
      formData.append('departmentID', this.myForm.get('departmentID').value);
      formData.append('name', this.myForm.get('name').value);
      formData.append('identification', this.myForm.get('identification').value);
      formData.append('hireDate', this.myForm.get('hireDate').value);
      formData.append('phone', this.myForm.get('phone').value);
      formData.append('mobileNumber', this.myForm.get('mobileNumber').value);
      formData.append('position', this.myForm.get('position').value);
      this.EmployeeManagmentService.AddNewEmployeeservice(formData).subscribe(
        response => {
          console.log('Employee Added successfully:', response);
          this.CloseFOrm();
        },
        error => {
          console.log('Error in Employee Adding :', error);
        }
      );
    } else {
      console.warn('Please Add Employee.');
    }
  }
  CloseFOrm(): void {
    this.dialogRef.close();
  }
}
