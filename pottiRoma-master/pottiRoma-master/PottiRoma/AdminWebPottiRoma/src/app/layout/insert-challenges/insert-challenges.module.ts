import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InsertChallengesRoutingModule } from './insert-challenges-routing.module';
import { InsertChallengesComponent } from './insert-challenges.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, InsertChallengesRoutingModule, PageHeaderModule],
    declarations: [InsertChallengesComponent]
})
export class InsertChallengesModule {}
