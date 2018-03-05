import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatNativeDateModule, MatDatepickerModule  } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { LoadingModule } from 'ngx-loading';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { InsertPointsRoutingModule } from './insert-points-routing.module';
import { InsertPointsComponent } from './insert-points.component';
import { PageHeaderModule } from './../../shared';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

@NgModule({
    imports: [
        CommonModule, 
        InsertPointsRoutingModule, 
        PageHeaderModule,
        MatButtonModule, 
        MatCheckboxModule, 
        FormsModule,  
        LoadingModule,
        MatFormFieldModule,
        MatInputModule,
        MatNativeDateModule, 
        MatDatepickerModule,
        MatAutocompleteModule],
    declarations: [InsertPointsComponent]
})
export class InsertPointsModule {}
