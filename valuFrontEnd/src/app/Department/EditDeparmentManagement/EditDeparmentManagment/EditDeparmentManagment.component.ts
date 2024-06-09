import { Component, OnInit ,Inject} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
} from '@angular/material/dialog';
import { DepartmentService } from 'src/app/Service/DepartmentService.service';

@Component({
  selector: 'app-EditUserManagment',
  templateUrl: './EditDeparmentManagment.component.html',
  styleUrls: ['./EditDeparmentManagment.component.scss']
})
export class EditDeparmentManagmentComponent implements OnInit {
  myForm: FormGroup;
  form : any;

  constructor(private fb: FormBuilder,  public dialogRef: MatDialogRef<EditDeparmentManagmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private DepartmentServiceManagement :DepartmentService) 
    {
      this.form =this.data.message;
      this.myForm = this.fb.group({
        name: [this.form.name, Validators.required],
        details: [this.form.details, Validators.required],
        order: [this.form.order, [Validators.required, Validators.min(1)]],
        id: [this.form.id],
  
      });
     }

  ngOnInit() {
  }
  EditDepartment()
  {
    if (this.myForm.valid) {

      const formData = new FormData();
      formData.append('id', this.myForm.get('id').value);
      formData.append('name', this.myForm.get('name').value);
      formData.append('details', this.myForm.get('details').value);
      formData.append('order', this.myForm.get('order').value);
      this.DepartmentServiceManagement.EditDepartments(formData).subscribe(res =>{
        this.CloseFOrm();
      },err =>{
        console.log(err);
      })
    } else {
      console.log('Form is invalid');
    }
  }
  CloseFOrm(): void {
    this.dialogRef.close();
  }

}
