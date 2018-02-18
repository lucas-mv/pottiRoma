import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesReportRoutingModule } from './sales-report-routing.module';
import { SalesReportComponent } from './sales-report.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, SalesReportRoutingModule, PageHeaderModule],
    declarations: [SalesReportComponent]
})
export class SalesReportModule {}
