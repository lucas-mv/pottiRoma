import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GameParametersRoutingModule } from './game-parameters-routing.module';
import { GameParametersComponent } from './game-parameters.component';
import { PageHeaderModule } from './../../shared';
import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatNativeDateModule, MatDatepickerModule  } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { LoadingModule } from 'ngx-loading';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material';

@NgModule({
    imports: [CommonModule, 
        GameParametersRoutingModule, 
        PageHeaderModule,
        MatButtonModule, 
        MatCheckboxModule, 
        FormsModule,  
        LoadingModule,
        MatFormFieldModule,
        MatInputModule,
        MatNativeDateModule, 
        MatDatepickerModule],
    declarations: [GameParametersComponent]
})
export class GameParametersModule {}
