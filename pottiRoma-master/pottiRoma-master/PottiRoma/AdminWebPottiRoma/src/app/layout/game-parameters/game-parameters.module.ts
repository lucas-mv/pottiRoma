import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GameParametersRoutingModule } from './game-parameters-routing.module';
import { GameParametersComponent } from './game-parameters.component';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, GameParametersRoutingModule, PageHeaderModule],
    declarations: [GameParametersComponent]
})
export class GameParametersModule {}
