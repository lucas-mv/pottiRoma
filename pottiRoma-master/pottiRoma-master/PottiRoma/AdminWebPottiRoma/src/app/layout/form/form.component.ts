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
    salespeople:any;
    motherFlowerEmail:string = '';
    name: string = '';
    primaryPhone :string = '';
    secondaryPhone: string = '';
    cpf: string = '';
    email: string = '';
    cep: string = '';
    birthday: Date;

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

    clickRegisterSalesperson(){
        if(this.email === '' || this.email === undefined ||
            this.name === '' || this.name === undefined || 
            this.cep === '' || this.cep === undefined ||
            this.primaryPhone === '' || this.primaryPhone === undefined ||
            this.cpf === '' || this.cpf === undefined ||
            this.name === '' || this.name === undefined || 
            this.birthday === null || this.birthday === undefined){
            this.toastr.error('Campos obrigatórios não preenchidos');
            return;
        }

        debugger;

        let selectedFlower: any = null;
        if(this.motherFlowerEmail !== ''){
            this.salespeople.forEach(salesperson => {
                if(salesperson.Email === this.motherFlowerEmail){
                    selectedFlower = salesperson;
                }
            });
        } 
        else{
            selectedFlower.UsuarioId = null;
        }

        debugger;

        this.loading = true;
        this.salespersonService.registerNewSalesperson(this.name, this.primaryPhone, this.secondaryPhone, this.cpf, this.email, this.cep, this.birthday, selectedFlower.UsuarioId)
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
