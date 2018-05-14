import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { ToastrService } from 'ngx-toastr';
import { GamificationService } from './../../shared/services/gamification.service';
import { ChallengeService } from './../../shared/services/challenge.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';
import { MatDialogModule } from '@angular/material';

@Component({
    selector: 'app-insert-challenges',
    templateUrl: './insert-challenges.component.html',
    styleUrls: ['./insert-challenges.component.scss'],
    animations: [routerTransition()]
})
export class InsertChallengesComponent implements OnInit {
    constructor(public dialog: MatDialog, private toastr:ToastrService, private gamificationService:GamificationService, private challengeService:ChallengeService) {}

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
    }

    onUpdateChallengeClick(){
        if(this.selectedChallenge.Parameter === undefined || this.selectedChallenge.Parameter === null ||
            this.selectedChallenge.Name === '' || this.selectedChallenge.Description === '' ||
            this.selectedChallenge.StartDate === undefined || this.selectedChallenge.StartDate === null ||
            this.selectedChallenge.EndDate === undefined || this.selectedChallenge.EndDate === null ||
            this.selectedChallenge.Goal === undefined || this.selectedChallenge.Goal === null ||
            this.selectedChallenge.Prize === undefined || this.selectedChallenge.Prize === null){
            this.toastr.error('Por favor preencha todos os campos para continuar!');
            return;
        }

        if(this.selectedChallenge.EndDate <= this.selectedChallenge.StartDate){
            this.toastr.error('A data final do desafio não pode ser menor do que a data inicial.');
            return;
        }

        let today = new Date();
        today.setHours(0);
        today.setMinutes(0);
        today.setSeconds(0);
        today.setMilliseconds(0);
        if(this.selectedChallenge.StartDate < today){
            this.toastr.error('A data inicial do desafio não pode ser anterior ao dia de hoje.');
            return;
        }

        if(this.selectedChallenge.Goal <= 0){
            this.toastr.error('O valor do objetivo não pode ser menor ou igual a zero.');
            return;
        }

        if(this.selectedChallenge.Prize <= 0){
            this.toastr.error('O valor das sementes não pode ser menor ou igual a zero.');
            return;
        }

        this.loading = true;
        this.challengeService.UpdateChallenge(this.selectedChallenge)
        .then((response) => 
        {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error(response.message);
            }
            else{
                this.toastr.success('Operação realizada com sucesso!');
            }
        });
    }

    onRemoveChallengeClick(){
        let dialogRef = this.dialog.open(ConfirmDeleteComponent, {
            width: '325px',
        });

        dialogRef.afterClosed().subscribe(result => {
            if(result === undefined || result === null || !result){
                return;
            }

            let today = new Date();
            today.setHours(0);
            today.setMinutes(0);
            today.setSeconds(0);
            today.setMilliseconds(0);
            this.selectedChallenge.EndDate = today;
            
            if(result !== undefined && result !== null){
                if(this.selectedChallenge.Parameter === undefined || this.selectedChallenge.Parameter === null ||
                    this.selectedChallenge.Name === '' || this.selectedChallenge.Description === '' ||
                    this.selectedChallenge.StartDate === undefined || this.selectedChallenge.StartDate === null ||
                    this.selectedChallenge.EndDate === undefined || this.selectedChallenge.EndDate === null ||
                    this.selectedChallenge.Goal === undefined || this.selectedChallenge.Goal === null ||
                    this.selectedChallenge.Prize === undefined || this.selectedChallenge.Prize === null){
                    this.toastr.error('Por favor preencha todos os campos para continuar!');
                    return;
                }
        
                if(this.selectedChallenge.Goal <= 0){
                    this.toastr.error('O valor do objetivo não pode ser menor ou igual a zero.');
                    return;
                }
        
                if(this.selectedChallenge.Prize <= 0){
                    this.toastr.error('O valor das sementes não pode ser menor ou igual a zero.');
                    return;
                }
        
                this.loading = true;
                this.challengeService.UpdateChallenge(this.selectedChallenge)
                .then((response) => 
                {
                    this.loading = false;
                    if(response.message === undefined || response.message === null || response.message === ''){
                        this.toastr.success('Desafio removido com sucesso! Atualize a página para ver a listagem mais recente de desafios.');
                    }
                    else{                        
                        this.toastr.error(response.message);
                    }
                });
            }
        });
    }

    onInsertChallengeClick() {
        debugger;
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
        debugger;
        this.loading = true;
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
}
