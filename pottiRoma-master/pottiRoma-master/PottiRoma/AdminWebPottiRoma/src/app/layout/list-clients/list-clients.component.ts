import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app-list-clients',
    templateUrl: './list-clients.component.html',
    styleUrls: ['./list-clients.component.scss'],
    animations: [routerTransition()]
})
export class ListClientsComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}
