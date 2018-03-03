import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { LoadingModule } from 'ngx-loading';
import { SalesReportService } from './../../shared/services/sales-report.service';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'app-sales-report',
    templateUrl: './sales-report.component.html',
    styleUrls: ['./sales-report.component.scss'],
    animations: [routerTransition()]
})
export class SalesReportComponent implements OnInit {
    constructor(private salesReportService: SalesReportService, private toastr: ToastrService) {}

    sales: any;
    loading: boolean = false;

    ngOnInit() {
        this.loading = true;
        this.salesReportService.getAllSales()
        .then(response => 
            {
                this.loading = false;
                if(response.message !== ''){
                    this.toastr.error(response.message);
                }
                else{
                    this.sales = response.sales;
                }
            })
    }

    generateSalesReport(){
        this.loading = true;
        this.salesReportService.generateSalesReport()
        .then(response => {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error(response.message);
            }
        });
    }    
}
