import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { SeasonService } from './../../shared/services/season.service';

@Component({
    selector: 'app-ranking',
    templateUrl: './ranking.component.html',
    styleUrls: ['./ranking.component.scss'],
    animations: [routerTransition()]
})
export class RankingComponent implements OnInit {
    constructor(private seasonService: SeasonService, private toastr:ToastrService) {}

    ranking:any;
    loading:boolean = false;

    ngOnInit() {
        this.loading = true;
        this.seasonService.getRankingBySeason()
        .then(response => 
            {
                this.loading = false;
                if(response.message !== ''){
                    this.toastr.error(response.message);
                }
                else{
                    this.ranking = response.ranking;
                }
            });
    }

    generateRankingReport(){
        this.loading = true;
        this.seasonService.generateRankingBySeasonReport()
        .then(response => {
            this.loading = false;
            if(response.message !== ''){
                this.toastr.error(response.message);
            }
        });
    }
}
