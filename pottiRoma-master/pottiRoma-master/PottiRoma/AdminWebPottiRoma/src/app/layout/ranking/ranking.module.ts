import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RankingRoutingModule } from './ranking-routing.module';
import { RankingComponent } from './ranking.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, RankingRoutingModule, PageHeaderModule],
    declarations: [RankingComponent]
})
export class RankingModule {}
