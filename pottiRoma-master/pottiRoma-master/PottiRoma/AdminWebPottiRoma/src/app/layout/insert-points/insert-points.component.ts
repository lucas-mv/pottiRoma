import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { ToastrService } from 'ngx-toastr';
import { SalespersonService } from './../../shared/services/salesperson.service'

@Component({
    selector: 'app-insert-points',
    templateUrl: './insert-points.component.html',
    styleUrls: ['./insert-points.component.scss'],
    animations: [routerTransition()]
})
export class InsertPointsComponent implements OnInit {
    constructor(private toastr:ToastrService, private salespersonService:SalespersonService) {}

    loading:boolean = false;
    salespeople:any;
    selectedSalespersonEmail:string = '';
    registerClients:Number;
    numberOfSales:Number;
    averageTicket:Number;
    registerReseller:Number;
    itensPerSale:Number;
    description:string = '';

    ngOnInit() {
        this.loading = true;
        this.salespersonService.getAllSalespeople()
        .then(response => 
            {
                this.loading = false;
                if(response.message !== ''){
                    this.toastr.error(response.message);
                }
                else{
                    this.salespeople = response.salespeople;
                }
            });
    }
}
