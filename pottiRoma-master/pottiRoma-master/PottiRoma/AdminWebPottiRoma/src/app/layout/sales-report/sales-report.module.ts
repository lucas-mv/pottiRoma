import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesReportRoutingModule } from './sales-report-routing.module';
import { SalesReportComponent } from './sales-report.component';
import { PageHeaderModule } from './../../shared';

import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { LoadingModule } from 'ngx-loading';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material';

import { SalesReportService } from './../../shared/services/sales-report.service';


@NgModule({
    imports: [
        CommonModule,
        SalesReportRoutingModule, 
        PageHeaderModule,
        MatButtonModule, 
        MatCheckboxModule, 
        FormsModule,  
        LoadingModule,
        MatFormFieldModule,
        MatInputModule
    ],
    declarations: [SalesReportComponent]
})
export class SalesReportModule {}
