import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { ClientsService } from './../../shared/services/clients.service';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { LoadingModule } from 'ngx-loading';

@Component({
    selector: 'app-list-clients',
    templateUrl: './list-clients.component.html',
    styleUrls: ['./list-clients.component.scss'],
    animations: [routerTransition()]
})
export class ListClientsComponent implements OnInit {
    constructor(private clientsService: ClientsService, private toastr: ToastrService) {}

    loading:boolean = false;
    clients:any;

    ngOnInit() {
        this.loading = true;
        this.clientsService.getAllClients()
        .then(response => 
            {
                this.loading = false;
                if(response.message !== ''){
                    this.toastr.error(response.message);
                }
                else{
                    this.clients = response.clients;
                }
            })
    }

    generateClientsReport(){
        this.loading = true;
        this.clientsService.generateClientsReport()
        .then(response => {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error(response.message);
            }
        });
    }    
}
