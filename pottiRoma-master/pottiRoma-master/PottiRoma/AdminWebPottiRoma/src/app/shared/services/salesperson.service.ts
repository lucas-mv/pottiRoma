import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';

@Injectable()
export class SalespersonService {

  constructor(private http: Http, private baseService: BaseService) { }

  registerNewSalesperson(name: string, primaryPhone :string, secondaryPhone: string, cpf: string, email: string, cep: string){
    return this.http
      .post(
        'http://localhost:51945/api/v1/User/Register',
        // 'https://pottiroma.azurewebsites.net/api/v1/User/Register',
        {
          Name: name,
          Email: email,
          Password: cpf,
          Cpf: cpf,
          PrimaryTelephone: primaryPhone,
          SecundaryTelephone: secondaryPhone,
          UserType: 1,
          Cep: cep,
          IsActive: true
        },
        this.baseService.createAuthenticationRequestOptions()
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
}
