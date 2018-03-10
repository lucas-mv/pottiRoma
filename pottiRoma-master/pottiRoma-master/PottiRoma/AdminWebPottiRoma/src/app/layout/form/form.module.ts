import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormRoutingModule } from './form-routing.module';
import { FormComponent } from './form.component';
import { PageHeaderModule } from './../../shared';
import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatNativeDateModule, MatDatepickerModule  } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { LoadingModule } from 'ngx-loading';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { MAT_DATE_LOCALE  } from '@angular/material/core';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

@NgModule({
    imports: [CommonModule, 
        FormRoutingModule, 
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
    declarations: [FormComponent],
    providers:[{provide: MAT_DATE_LOCALE, useValue: 'pt-BR'}]
})
export class FormModule {
}
