import { Component, OnInit } from '@angular/core';
import {Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ForgotPasswordComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  email:string = '';

  ngOnInit() {
  }

  onResetPasswordClick() {
    this.dialogRef.close(this.email);
  }

  onCancelClick() {
    this.dialogRef.close();
  }

}
