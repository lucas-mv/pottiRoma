import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app-game-parameters',
    templateUrl: './game-parameters.component.html',
    styleUrls: ['./game-parameters.component.scss'],
    animations: [routerTransition()]
})
export class GameParametersComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}
