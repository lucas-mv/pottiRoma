import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { SalespersonService } from './../../shared/services/salesperson.service';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';


@Component({
    selector: 'app-reseller',
    templateUrl: './reseller.component.html',
    styleUrls: ['./reseller.component.scss'],
    animations: [routerTransition()]
})
export class ResellerComponent implements OnInit {
    constructor(private salespersonService:SalespersonService, private toastr: ToastrService) {}

    loading:boolean = false;
    salespeople:any;

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
            })
    }

    generateSalespeopleReport(){
        this.loading = true;
        this.salespersonService.generateSalespeopleReport()
        .then(response => {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error(response.message);
            }
        });
    }   

    onSalespersonStatusChange(salesperson:any){
        this.loading = true;
        this.salespersonService.updateStatus(salesperson.UsuarioId, !salesperson.IsActive)
        .then(response => {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error(response.message);
            }
            else{
                this.toastr.success('Operação concluída com sucesso!');
            }
        });
    }
}
