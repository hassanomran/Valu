import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditDeparmentManagmentComponent } from '../../EditDeparmentManagement/EditDeparmentManagment/EditDeparmentManagment.component';
import { IDeparment } from 'src/app/Models/IDeparment';
import { DepartmentService } from 'src/app/Service/DepartmentService.service';
import { AddDepartmentManagementComponent } from '../../AddDepartmentManagement/AddDepartmentManagement/AddDepartmentManagement.component';


@Component({
  selector: 'app-Departmentmanagment',
  templateUrl: './Departmentmanagment.component.html',
  styleUrls: ['./Departmentmanagment.component.scss']
})
export class DepartmentmanagmentComponent implements OnInit {
  dataSource : IDeparment[];
  displayedColumns: string[] = [
    'name',
    'details',
    'order',
    'edit',
    'delete'
  ];
  DepartmentId: any;

  constructor(private DepartmentServiceManagement :DepartmentService,public dialog: MatDialog) { }

  ngOnInit() {
    this.DepartmentServiceManagement.GetRefershLoadUsers().subscribe(user =>{
      this.GetAllUSersService();
    });
    this.GetAllUSersService();
  }
  GetAllUSersService()
  {
    this.DepartmentServiceManagement.GetAllDepartmentsService().subscribe(
      data => {
        this.dataSource = data;
      },
      error => {
        console.log(error);
      }
    );  
  }
  DeleteDepartment(DeleteDepartment: any)
  {
    this.DepartmentId = DeleteDepartment;
    this.DepartmentServiceManagement.DeleteDepartmentsService(this.DepartmentId.id).subscribe(res =>{

    },err =>{
      console.log(err);
    })
  }
  openAddFormDialog(): void {
    const dialogRef = this.dialog.open(AddDepartmentManagementComponent, {});
    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
    });
  }
  openEditFormDialog(): void {
    const dialogRef = this.dialog.open(EditDeparmentManagmentComponent, {
      data: { message: this.DepartmentId },
    });
    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
    });
  }
  EditDepartment(Department: any) {
    this.DepartmentId = Department;
  }


}
