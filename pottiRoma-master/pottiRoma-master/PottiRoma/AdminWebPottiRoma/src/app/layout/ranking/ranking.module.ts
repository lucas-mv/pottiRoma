import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingModule } from 'ngx-loading';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { RankingRoutingModule } from './ranking-routing.module';
import { RankingComponent } from './ranking.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, RankingRoutingModule, PageHeaderModule, LoadingModule, MatButtonModule, MatCheckboxModule],
    declarations: [RankingComponent]
})
export class RankingModule {}
