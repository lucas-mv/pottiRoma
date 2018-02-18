import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GameParametersComponent } from './game-parameters.component';

const routes: Routes = [
    {
        path: '', component: GameParametersComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class GameParametersRoutingModule {
}
