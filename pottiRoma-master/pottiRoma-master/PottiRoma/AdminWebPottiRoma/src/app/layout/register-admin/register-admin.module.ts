import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegisterAdminRoutingModule } from './register-admin-routing.module';
import { RegisterAdminComponent } from './register-admin.component';
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
        RegisterAdminRoutingModule, 
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
    declarations: [RegisterAdminComponent]
})
export class RegisterAdminModule {}
