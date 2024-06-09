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
@Component({
  selector: 'app-AddUserManagement',
  templateUrl: './AddDepartmentManagement.component.html',
  styleUrls: ['./AddDepartmentManagement.component.scss']
})
export class AddDepartmentManagementComponent implements OnInit {
  myForm: FormGroup;

  constructor(private fb: FormBuilder,  public dialogRef: MatDialogRef<AddDepartmentManagementComponent>,private DepartmentServiceManagement :DepartmentService)
   { 
    this.myForm = this.fb.group({
      name: ['', Validators.required],
      details: ['', Validators.required],
      order: ['', [Validators.required, Validators.min(1)]],
    });
   }

  ngOnInit() {
  }
  AddNewDepartment(): void {
    if (this.myForm.valid) {
      const formData = new FormData();
      formData.append('name', this.myForm.get('name').value);
      formData.append('details', this.myForm.get('details').value);
      formData.append('order', this.myForm.get('order').value);
      this.DepartmentServiceManagement.AddNewDepartmentsService(formData).subscribe(
        response => {
          console.log('Department Added successfully:', response);
          this.CloseFOrm();
        },
        error => {
          console.log('Error in Department Adding :', error);
        }
      );
    } else {
      console.warn('Please Add Department name.');
    }
  }
  CloseFOrm(): void {
    this.dialogRef.close();
  }
}
