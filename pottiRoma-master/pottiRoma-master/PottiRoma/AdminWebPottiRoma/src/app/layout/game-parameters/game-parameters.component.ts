import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { GamificationService } from './../../shared/services/gamification.service'
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-game-parameters',
    templateUrl: './game-parameters.component.html',
    styleUrls: ['./game-parameters.component.scss'],
    animations: [routerTransition()]
})
export class GameParametersComponent implements OnInit {
    constructor(private gamificationService: GamificationService, private toastr:ToastrService) {}

    loading:boolean;
    registerClients:Number;
    numberOfSales:Number;
    averageTicketValue:Number;
    registerReseller:Number;
    itensPerSale:Number;

    ngOnInit() {
        this.loading = true;
        this.gamificationService.getCurrentGamificationPoints()
        .then(response => {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error('Ocorreu um erro ao buscar os parâmetros atuais do jogo.');
            }
            else{
                this.registerClients = response.gamificationPoints.RegisterNewClients;
                this.numberOfSales = response.gamificationPoints.SalesNumber;
                this.averageTicketValue = response.gamificationPoints.AverageTicket;
                this.registerReseller = response.gamificationPoints.InviteFlower;
                this.itensPerSale = response.gamificationPoints.RegisterNewClients;
            }
        });
    }

    updateGamificationPoints(){
        this.loading = true;
        this.gamificationService.updateGamificationPoints(this.averageTicketValue, this.registerClients, this.numberOfSales, this.itensPerSale, this.registerReseller)
        .then(response => {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error(response.message);
            }
            else{
                this.toastr.success('Parâmetros do jogo atualizados com sucesso!');
            }
        });
    }
}
