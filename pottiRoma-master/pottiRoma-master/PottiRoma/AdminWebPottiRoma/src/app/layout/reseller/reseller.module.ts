import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingModule } from 'ngx-loading';
import { MatButtonModule, MatCheckboxModule, MatNativeDateModule, MatDatepickerModule  } from '@angular/material';
import { FormsModule } from '@angular/forms';

import { ResellerRoutingModule } from './reseller-routing.module';
import { ResellerComponent } from './reseller.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [
        CommonModule, 
        ResellerRoutingModule, 
        PageHeaderModule, 
        LoadingModule, 
        MatButtonModule, 
        MatCheckboxModule,
        FormsModule
    ],
    declarations: [ResellerComponent]
})
export class ResellerModule {}
