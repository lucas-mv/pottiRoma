import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InsertPointsComponent } from './insert-points.component';

const routes: Routes = [
    {
        path: '', component: InsertPointsComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class InsertPointsRoutingModule {
}
