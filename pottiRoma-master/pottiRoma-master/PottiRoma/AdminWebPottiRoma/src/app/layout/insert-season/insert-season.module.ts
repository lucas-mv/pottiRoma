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
import { InsertSeasonRoutingModule } from './insert-season-routing.module';
import { InsertSeasonComponent } from './insert-season.component';
import { PageHeaderModule } from './../../shared';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

@NgModule({
    imports: [
        CommonModule,
        InsertSeasonRoutingModule,
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
    declarations: [InsertSeasonComponent]
})
export class InsertSeasonModule {}
