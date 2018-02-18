import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app-insert-points',
    templateUrl: './insert-points.component.html',
    styleUrls: ['./insert-points.component.scss'],
    animations: [routerTransition()]
})
export class InsertPointsComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}
