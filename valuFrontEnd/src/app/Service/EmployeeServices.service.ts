import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IEmployee } from '../Models/IEmployee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServicesService {
  GetAllEmployeesUrl=environment.ApiUrl+'/Employee/GetAllEmployee';
  AddEmployeesUrl=environment.ApiUrl+'/Employee/AddEmployee';
  EditEmployeesUrl=environment.ApiUrl+'/Employee/UpdateEmployee';
  DeleteEmployeeUrl=environment.ApiUrl+'/Employee/DeleteEmployee';
constructor(private http: HttpClient) { }
private LoadEmployee = new Subject<void>();
GetRefershLoadEmployee() {
  return this.LoadEmployee;
}

GetAllEmployeekservice() {
  return this.http.get<IEmployee[]>(this.GetAllEmployeesUrl);
}
AddNewEmployeeservice(formData:any): Observable<any> {
  return this.http.post(this.AddEmployeesUrl, formData)
  .pipe(
    tap(() => {
      this.LoadEmployee.next();
    })
  );
}
EditEmployeeservice(formData:any): Observable<any> {
  return this.http.put(this.EditEmployeesUrl, formData)
  .pipe(
    tap(() => {
      this.LoadEmployee.next();
    })
  );
}
DeleteEmployeerService(Taskid:any)
{
  return this.http.delete(this.DeleteEmployeeUrl +'?id='+Taskid, {
    headers: {
      'Content-Type': 'application/json',
    },
  })
  .pipe(
    tap(() => {
      this.LoadEmployee.next();
    })
  );
}
}
