import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { ToastrService } from 'ngx-toastr';
import { SalespersonService } from './../../shared/services/salesperson.service';

@Component({
    selector: 'app-register-admin',
    templateUrl: './register-admin.component.html',
    styleUrls: ['./register-admin.component.scss'],
    animations: [routerTransition()]
})
export class RegisterAdminComponent implements OnInit {
    constructor(private salespersonService: SalespersonService, private toastr:ToastrService) {}

    loading:boolean = false;
    salespeople:any;
    name: string = '';
    primaryPhone :string = '';
    secondaryPhone: string = '';
    cpf: string = '';
    email: string = '';
    cep: string = '';
    birthday: Date;

    ngOnInit() {
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

        this.loading = true;
        this.salespersonService.registerNewAdminstrator(this.name, this.primaryPhone, this.secondaryPhone, this.cpf, this.email, this.cep, this.birthday)
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
