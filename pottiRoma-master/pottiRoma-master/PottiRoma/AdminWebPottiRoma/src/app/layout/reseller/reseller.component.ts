import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app-reseller',
    templateUrl: './reseller.component.html',
    styleUrls: ['./reseller.component.scss'],
    animations: [routerTransition()]
})
export class ResellerComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}
