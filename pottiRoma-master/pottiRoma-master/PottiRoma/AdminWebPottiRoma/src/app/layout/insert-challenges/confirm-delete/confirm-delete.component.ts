import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.scss']
})
export class ConfirmDeleteComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ConfirmDeleteComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
  }

  onContinueClick() {
    this.dialogRef.close(true);
  }

  onCancelClick() {
    this.dialogRef.close();
  }

}
