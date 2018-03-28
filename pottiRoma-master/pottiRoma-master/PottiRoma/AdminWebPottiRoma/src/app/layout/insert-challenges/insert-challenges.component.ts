import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { ToastrService } from 'ngx-toastr';
import { GamificationService } from './../../shared/services/gamification.service';
import { ChallengeService } from './../../shared/services/challenge.service';


@Component({
    selector: 'app-insert-challenges',
    templateUrl: './insert-challenges.component.html',
    styleUrls: ['./insert-challenges.component.scss'],
    animations: [routerTransition()]
})
export class InsertChallengesComponent implements OnInit {
    constructor(private toastr:ToastrService, private gamificationService:GamificationService, private challengeService:ChallengeService) {}

    challenges:any;
    selectedChallenge:any = null;

    challengeTypes:any = [
        {
            parametro: 3,
            nome: 'Cadastro de Clientes'
        },
        {
            parametro: 2,
            nome: 'Convidar Flores Aliadas'
        },
        {
            parametro: 1,
            nome: 'Vendas Efetuadas'
        },
    ];

    loading:boolean = false;
    startDate:Date;
    endDate:Date;
    challengeName:string = '';
    description:string = '';
    seedAmount:Number;
    goal:Number;
    challengeParameter:Number;

    ngOnInit()
    {
        this.loading = true;
        this.challengeService.getCurrentChallenges()
        .then(response =>
            {
                this.loading = false;
                if(response.message !== ''){
                    this.toastr.error(response.message);
                }
                else{
                    this.challenges = response.challenges;
                    this.challenges.unshift({Name: 'Cancelar edição'});
                }
            })
    }

    onSelectedChallengeChange(challenge:any){
        if(challenge.Name === 'Cancelar edição')
            this.selectedChallenge = null;

            debugger;
    }

    onUpdateChallengeClick(){
        debugger;
    }

    onInsertChallengeClick(){
        if(this.challengeParameter === undefined || this.challengeParameter === null ||
            this.challengeName === '' || this.description === '' ||
            this.startDate === undefined || this.startDate === null ||
            this.endDate === undefined || this.endDate === null ||
            this.goal === undefined || this.goal === null ||
            this.seedAmount === undefined || this.seedAmount === null){
            this.toastr.error('Por favor preencha todos os campos para continuar!');
            return;
        }

        if(this.endDate <= this.startDate){
            this.toastr.error('A data final do desafio não pode ser menor do que a data inicial.');
            return;
        }

        let today = new Date();
        today.setHours(0);
        today.setMinutes(0);
        today.setSeconds(0);
        today.setMilliseconds(0);
        if(this.startDate < today){
            this.toastr.error('A data inicial do desafio não pode ser anterior ao dia de hoje.');
            return;
        }

        if(this.goal <= 0){
            this.toastr.error('O valor do objetivo não pode ser menor ou igual a zero.');
            return;
        }

        if(this.seedAmount <= 0){
            this.toastr.error('O valor das sementes não pode ser menor ou igual a zero.');
            return;
        }

        this.loading = true;
        if(this.selectedChallenge.name == null){
            this.gamificationService.insertNewChallenge(this.challengeName, this.startDate, this.endDate, this.challengeParameter, this.goal, this.seedAmount, this.description)
            .then(response => {
                this.loading = false;
                if(response.message === ''){
                    this.toastr.success('Desafio inserido com sucesso!');
                }
                else{
                    this.toastr.error(response.message);
                }
            });
        }
        else
        {
            this.selectedChallenge.Name = this.challengeName;
            this.selectedChallenge.startDate = this.startDate;
            this.selectedChallenge.parameter = this.challengeParameter;
            this.selectedChallenge.seedAmount = this.seedAmount;
            this.selectedChallenge.description = this.description;
            this.challengeService.UpdateChallenge(this.selectedChallenge)
            .then(response => {
                this.loading = false;
                if(response.message === ''){
                    this.toastr.success('Desafio alterado com sucesso!');
                }
                else{
                    this.toastr.error(response.message);
                }
            });
        }
    }
}
