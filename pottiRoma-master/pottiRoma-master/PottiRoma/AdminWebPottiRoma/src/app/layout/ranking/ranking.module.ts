import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingModule } from 'ngx-loading';

import { RankingRoutingModule } from './ranking-routing.module';
import { RankingComponent } from './ranking.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, RankingRoutingModule, PageHeaderModule, LoadingModule],
    declarations: [RankingComponent]
})
export class RankingModule {}
