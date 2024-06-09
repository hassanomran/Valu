import { IEmployee } from './../../../Models/IEmployee';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditEmployeeManagment} from '../../Edit Employee/Edit EmployeeManagment/EditEmployeeManagment.component';
import { AddEmployeeManagment } from '../../Add Employee/Add EmployeeManagment/AddEmployeeManagment.component';
import { EmployeeServicesService } from 'src/app/Service/EmployeeServices.service';


@Component({
  selector: 'app-EmployeeListManagment',
  templateUrl: './EmployeeListManagment.component.html',
  styleUrls: ['./EmployeeListManagment.component.scss']
})
export class EmployeeListManagment implements OnInit {
  dataSource : IEmployee[];
  displayedColumns: string[] = [
    'name',
    'departmentName',
    'name',
    'identification',
    'phone',
    'mobileNumber',
    'hireDate',
    'position',
    'edit',
    'delete'
  ];
  EmployeeID: any;
  constructor(private EmployeeManagmentService: EmployeeServicesService,public dialog: MatDialog) { }

  ngOnInit() {
    this.EmployeeManagmentService.GetRefershLoadEmployee().subscribe(task =>{
      this.GetAllEmployeeService();
    });
    this.GetAllEmployeeService();
  }
  GetAllEmployeeService()
  {
    this.EmployeeManagmentService.GetAllEmployeekservice().subscribe(
      data => {
        this.dataSource = data;
      },
      error => {
        console.log(error);
      }
    );  
  }
  DeleteEmployeeService(Employee: any)
  {
    this.EmployeeID = Employee;
    console.log(this.EmployeeID);
    this.EmployeeManagmentService.DeleteEmployeerService(this.EmployeeID.id).subscribe(res =>{

    },err =>{
      console.log(err);
    })
  }
  openAddFormDialog(): void {
    const dialogRef = this.dialog.open(AddEmployeeManagment, {});
    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
    });
  }
  openEditFormDialog(): void {
    const dialogRef = this.dialog.open(EditEmployeeManagment, {
      data: { message: this.EmployeeID },
    });
    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
    });
  }
  EditEmployee(Employee: any) {
    console.log(Employee)
    this.EmployeeID = Employee;
  }

}
