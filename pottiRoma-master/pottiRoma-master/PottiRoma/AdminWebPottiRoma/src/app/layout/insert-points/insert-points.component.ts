import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { ToastrService } from 'ngx-toastr';
import { SalespersonService } from './../../shared/services/salesperson.service'
import { GamificationService } from './../../shared/services/gamification.service'

@Component({
    selector: 'app-insert-points',
    templateUrl: './insert-points.component.html',
    styleUrls: ['./insert-points.component.scss'],
    animations: [routerTransition()]
})
export class InsertPointsComponent implements OnInit {
    constructor(private toastr:ToastrService, private salespersonService:SalespersonService, private gamificationService:GamificationService) {}

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

    InsertSeedsForSalePerson(){
        this.loading = true;
        this.gamificationService.InsertSeedsForSalePerson(this.selectedSalespersonEmail,this.averageTicket,this.registerClients,this.salespeople, this.itensPerSale, this.registerReseller,this.description)
        .then(response => {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error(response.message);
            }
            else {
                this.toastr.success('Operação realizada com sucesso!');
            }
        });
        this.selectedSalespersonEmail='';
        this.averageTicket = 0;
        this.description = '';
        this.itensPerSale = 0;
        this.numberOfSales = 0;
        this.registerClients = 0;
        this.registerReseller = 0;
    }    
}
