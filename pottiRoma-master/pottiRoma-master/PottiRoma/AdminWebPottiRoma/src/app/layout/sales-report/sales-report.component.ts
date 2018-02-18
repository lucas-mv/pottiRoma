import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app-sales-report',
    templateUrl: './sales-report.component.html',
    styleUrls: ['./sales-report.component.scss'],
    animations: [routerTransition()]
})
export class SalesReportComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}
