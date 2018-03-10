import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';

@Injectable()
export class SalespersonService extends BaseService {

  constructor(private http: Http) {
    super();
   }

   public registerNewAdminstrator(name: string, primaryPhone :string, secondaryPhone: string, cpf: string, email: string, cep: string, birthday:Date){
    return this.http
      .post(
        this.getBaseUrl() + 'User/Register',
        {
          Name: name,
          Email: email,
          Password: cpf,
          Cpf: cpf,
          PrimaryTelephone: primaryPhone,
          SecundaryTelephone: secondaryPhone,
          UserType: 2,
          Cep: cep,
          IsActive: true,
          Birthday: birthday,
          MotherFlowerId: null
        },
        this.createAuthenticationRequestOptions()
      )
      .toPromise()
      .then(res => {
        let responseJson = res.json();
        return {
          user: responseJson.User,
          message: ''
        };
      })
      .catch(res => {
        return {
          user: null,
          message: res._body
        }
      });
  }

   public registerNewSalesperson(name: string, primaryPhone :string, secondaryPhone: string, cpf: string, email: string, cep: string, birthday:Date, motherFlowerId:string){
    return this.http
      .post(
        this.getBaseUrl() + 'User/Register',
        {
          Name: name,
          Email: email,
          Password: cpf,
          Cpf: cpf,
          PrimaryTelephone: primaryPhone,
          SecundaryTelephone: secondaryPhone,
          UserType: 1,
          Cep: cep,
          IsActive: true,
          Birthday: birthday,
          MotherFlowerId: motherFlowerId
        },
        this.createAuthenticationRequestOptions()
      )
      .toPromise()
      .then(res => {
        let responseJson = res.json();
        return {
          user: responseJson.User,
          message: ''
        };
      })
      .catch(res => {
        return {
          user: null,
          message: res._body
        }
      });
  }

  public getAllSalespeople(){
    return this.http
    .post(
      this.getBaseUrl() + 'User/GetAppUsers',
      null,
      this.createAuthenticationRequestOptions()
    )
    .toPromise()
    .then(res => {
      let responseJson = res.json();
      return {
        salespeople: responseJson.Users,
        message: ''
      };
    })
    .catch(res => {
      return {
        salespeople: null,
        message: res._body
      }
    });
   }

   public generateSalespeopleReport(){
    return this.http
      .get(
        this.getBaseUrl() + 'User/Report',
        this.createBlobAuthenticationRequestOptions()
      )
      .toPromise()
      .then(res => {        
        let date = new Date();
        let fileName = 'RelatorioRevendedoras_' + date.getDate() + '-' + (date.getMonth()+1) + '-' + date.getFullYear() + '.xlsx';
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
}
