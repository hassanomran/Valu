import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { IDeparment } from '../Models/IDeparment';
import { Observable, Subject } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  GetAllDepartmentUrl=environment.ApiUrl+'/Department/GetAllDepartments';
  AddDepartmentUrl=environment.ApiUrl+'/Department/AddDepartment';
  EditDepartmentUrl=environment.ApiUrl+'/Department/EditDepartment';
  DeleteDepartmentUrl=environment.ApiUrl+'/Department/DeleteDepartment';


constructor(private http: HttpClient) { }
private LoadUsers = new Subject<void>();
GetRefershLoadUsers() {
  return this.LoadUsers;
}

GetAllDepartmentsService() {
  return this.http.get<IDeparment[]>(this.GetAllDepartmentUrl);
}
AddNewDepartmentsService(formData:any): Observable<any> {
  return this.http.post(this.AddDepartmentUrl, formData)
  .pipe(
    tap(() => {
      this.LoadUsers.next();
    })
  );
}
EditDepartments(formData:any): Observable<any> {
  return this.http.put(this.EditDepartmentUrl, formData)
  .pipe(
    tap(() => {
      this.LoadUsers.next();
    })
  );
}
DeleteDepartmentsService(UserId:any)
{
  return this.http.delete(this.DeleteDepartmentUrl +'?id='+UserId, {
    headers: {
      'Content-Type': 'application/json',
    },
  })
  .pipe(
    tap(() => {
      this.LoadUsers.next();
    })
  );
}
}
