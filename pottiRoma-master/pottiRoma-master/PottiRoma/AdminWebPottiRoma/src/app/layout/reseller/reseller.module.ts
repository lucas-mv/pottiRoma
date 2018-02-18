import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResellerRoutingModule } from './reseller-routing.module';
import { ResellerComponent } from './reseller.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, ResellerRoutingModule, PageHeaderModule],
    declarations: [ResellerComponent]
})
export class ResellerModule {}
