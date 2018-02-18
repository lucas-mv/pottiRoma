import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InsertPointsRoutingModule } from './insert-points-routing.module';
import { InsertPointsComponent } from './insert-points.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, InsertPointsRoutingModule, PageHeaderModule],
    declarations: [InsertPointsComponent]
})
export class InsertPointsModule {}
