import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            { path: '', redirectTo: 'dashboard' },
            { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardModule' },
            { path: 'sales-report', loadChildren: './sales-report/sales-report.module#SalesReportModule' },
            { path: 'insert-points', loadChildren: './insert-points/insert-points.module#InsertPointsModule' },
            { path: 'game-parameters', loadChildren: './game-parameters/game-parameters.module#GameParametersModule' },
            { path: 'reseller', loadChildren: './reseller/reseller.module#ResellerModule' },
            { path: 'charts', loadChildren: './charts/charts.module#ChartsModule' },
            { path: 'list-clients', loadChildren: './list-clients/list-clients.module#ListClientsModule' },
            { path: 'ranking', loadChildren: './ranking/ranking.module#RankingModule' },
            { path: 'tables', loadChildren: './tables/tables.module#TablesModule' },
            { path: 'forms', loadChildren: './form/form.module#FormModule' },
            { path: 'bs-element', loadChildren: './bs-element/bs-element.module#BsElementModule' },
            { path: 'grid', loadChildren: './grid/grid.module#GridModule' },
            { path: 'components', loadChildren: './bs-component/bs-component.module#BsComponentModule' },
            { path: 'blank-page', loadChildren: './blank-page/blank-page.module#BlankPageModule' }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutRoutingModule {}
