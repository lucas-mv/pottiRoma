import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';

@Injectable()
export class GamificationService extends BaseService {

  constructor(private http:Http) {
    super();
   }


  public getCurrentGamificationPoints(){
    return this.http
    .get(
      this.getBaseUrl() + 'GamificationPoints/GetCurrent',
      this.createAuthenticationRequestOptions()
    )
    .toPromise()
    .then(res => {
      let responseJson = res.json();
      return {
        gamificationPoints: responseJson.Entity,
        message: ''
      };
    })
    .catch(res => {
      return {
        gamificationPoints: null,
        message: res._body
      }
    });
  }

  public InsertSeedsForSalePerson(email:string, averageTicket:Number, registerNewClients:Number, salesNumber:Number, averageItensPerSale:Number, inviteFlower:Number, description:string){
    return this.http
    .post(
      this.getBaseUrl() + 'LogInsertPoints/New',
      {
        UserEmail: email,
        AverageTicket: averageTicket,
        RegisterNewClients: registerNewClients,
        SalesNumber: salesNumber,
        AverageItensPerSale: averageItensPerSale,
        InviteFlower: inviteFlower,
        Description: description,
        IsActive: true
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

  public updateGamificationPoints(averageTicket:Number, registerNewClients:Number, salesNumber:Number, averageItensPerSale:Number, inviteFlower:Number){
    return this.http
    .post(
      this.getBaseUrl() + 'GamificationPoints/Update',
      {
        AverageTicket: averageTicket,
        RegisterNewClients: registerNewClients,
        SalesNumber: salesNumber,
        AverageItensPerSale: averageItensPerSale,
        InviteFlower: inviteFlower,
        IsActive: true
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

  public insertNewChallenge(name:string, startDate: Date, endDate:Date, parameter:Number, goal:Number, prize:Number, description:string){
    return this.http
    .post(
      this.getBaseUrl() + 'Challenge/Insert',
      {
        Name: name,
        StartDate: startDate,
        EndDate: endDate,
        Parameter: parameter,
        Goal: goal,
        Prize: prize,
        Description: description
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
