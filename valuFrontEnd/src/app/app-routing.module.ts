import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeListManagment } from './Employee/EmployeeList/EmployeeListManagment.component.htmlListManagment/EmployeeListManagment.component';
import { DepartmentmanagmentComponent } from './Department/DepartmentManagment/Departmentmanagment/Departmentmanagment.component';

const routes: Routes = [
  { path: '', redirectTo: '/task', pathMatch: 'full' },
  {path: 'Department', component:DepartmentmanagmentComponent},
  {path: 'Employee', component:EmployeeListManagment}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
