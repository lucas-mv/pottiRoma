import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { SalespersonService } from './../../shared/services/salesperson.service';

@Component({
    selector: 'app-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.scss'],
    animations: [routerTransition()]
})
export class FormComponent implements OnInit {
    constructor(public forms: FormsModule, private toastr: ToastrService, private salespersonService: SalespersonService) {}
    
    loading:boolean = false;
    name: string;
    primaryPhone :string;
    secondaryPhone: string;
    cpf: string;
    email: string;
    cep: string;

    ngOnInit() {

    }

    clickRegisterSalesperson(){
        this.loading = true;
        this.salespersonService.registerNewSalesperson(this.name, this.primaryPhone, this.secondaryPhone, this.cpf, this.email, this.cep)
        .then(response => {
            this.loading = false;
            if(response.message === ''){
                this.toastr.success('Operação concluida com sucesso!');
            }
            else{
                this.toastr.error(response.message);
            }
        });
    }
}
