import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Http } from '@angular/http';

@Injectable()
export class SeasonService extends BaseService {

  constructor(private http:Http) {
    super();
   }

   public getRankingBySeason(){
    return this.http
    .get(
      this.getBaseUrl() + 'Season/RankingBySeason',
      this.createAuthenticationRequestOptions()
    )
    .toPromise()
    .then(res => {
      let responseJson = res.json();
      return {
        ranking: responseJson.RankingBySeason,
        message: ''
      };
    })
    .catch(res => {
      return {
        ranking: null,
        message: res._body
      }
    });
   }

   public generateRankingBySeasonReport(){
    return this.http
      .get(
        this.getBaseUrl() + 'Season/Report',
        this.createBlobAuthenticationRequestOptions()
      )
      .toPromise()
      .then(res => {
        let date = new Date();
        let fileName = 'RelatorioRankingPorTemporada_' + date.getDate() + '-' + (date.getMonth()+1) + '-' + date.getFullYear() + '.xlsx';
        this.saveAsBlob(res, fileName);
        return {
          message: ''
        };
      })
      .catch(res => {
        return {
          message: res._body
        }
      });
  }

  public insertSeason(name: string, startDate: Date, endDate: Date, isActive: boolean ){
    return this.http
      .post(
        this.getBaseUrl() + 'Season/Insert',
      {
        Name: name,
        StartDate: startDate,
        EndDate: endDate,
        IsActive: true,
      },
      this.createAuthenticationRequestOptions()
    )
    .toPromise()
    .then(res => {
      return {
        message: ''
      };
    })
    .catch(res => {
      return {
        message: res._body
      }
    });
  }

}
