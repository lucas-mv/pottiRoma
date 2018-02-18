import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app-ranking',
    templateUrl: './ranking.component.html',
    styleUrls: ['./ranking.component.scss'],
    animations: [routerTransition()]
})
export class RankingComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}
