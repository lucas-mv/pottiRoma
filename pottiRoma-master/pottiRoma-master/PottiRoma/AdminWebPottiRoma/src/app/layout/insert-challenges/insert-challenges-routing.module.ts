import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InsertChallengesComponent } from './insert-challenges.component';

const routes: Routes = [
    {
        path: '', component: InsertChallengesComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class InsertChallengesRoutingModule {
}
