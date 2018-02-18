import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app-insert-challenges',
    templateUrl: './insert-challenges.component.html',
    styleUrls: ['./insert-challenges.component.scss'],
    animations: [routerTransition()]
})
export class InsertChallengesComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}
