import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InsertChallengesRoutingModule } from './insert-challenges-routing.module';
import { InsertChallengesComponent } from './insert-challenges.component';
import { PageHeaderModule } from './../../shared';

import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatNativeDateModule, MatDatepickerModule  } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { LoadingModule } from 'ngx-loading';
import { MatFormFieldModule, MatSelectModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { MAT_DATE_LOCALE  } from '@angular/material/core';
import { MatAutocompleteModule } from '@angular/material/autocomplete';


@NgModule({
    imports: [
        CommonModule, 
        InsertChallengesRoutingModule,
        PageHeaderModule,
        FormsModule,  
        LoadingModule,
        MatFormFieldModule,
        MatButtonModule,
        MatInputModule,
        MatNativeDateModule, 
        MatDatepickerModule,
        MatAutocompleteModule,
        MatSelectModule
    ],
    declarations: [InsertChallengesComponent],
    providers:[{provide: MAT_DATE_LOCALE, useValue: 'pt-BR'}]
})
export class InsertChallengesModule {}
