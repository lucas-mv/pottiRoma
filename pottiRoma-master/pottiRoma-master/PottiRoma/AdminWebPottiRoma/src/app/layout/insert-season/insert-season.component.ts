import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { ToastrService } from 'ngx-toastr';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import { SalespersonService } from './../../shared/services/salesperson.service';
import { GamificationService } from './../../shared/services/gamification.service';
import { SeasonService } from './../../shared/services/season.service';

@Component({
    selector: 'app-insert-season',
    templateUrl: './insert-season.component.html',
    styleUrls: ['./insert-season.component.scss'],
    animations: [routerTransition()]
})
export class InsertSeasonComponent implements OnInit {
    constructor(private toastr:ToastrService, private seasonService:SeasonService) {}

    loading: boolean = false;
    name: string;
    startDate: Date;
    endDate: Date;
    isActive: boolean = true;


    ngOnInit() {
    }

    insertSeason(){
        if(this.startDate === undefined || this.startDate === null ||
            this.endDate === undefined || this.endDate === null ||
            this.name === undefined || this.name === null){
            this.toastr.error('Por favor preencha todos os campos para continuar!');
            return;
        }
        if ( this.endDate <= this.startDate){
            this.toastr.error('A data final da temporada não pode ser menor do que a data inicial.');
            return;
        }

        this.loading = true;
        debugger;
        this.seasonService.insertSeason(this.name, this.startDate, this.endDate, this.isActive)
        .then(response => {
            this.loading = false;
            if(response.message === ''){
                this.toastr.success('Temporada inserida com sucesso!');
            }
            else{
                this.toastr.error(response.message);
            }
        });
    }
}
