import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';

@Injectable()
export class SalespersonService extends BaseService {

  constructor(private http: Http) {
    super();
   }

   public registerNewSalesperson(name: string, primaryPhone :string, secondaryPhone: string, cpf: string, email: string, cep: string){
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
          IsActive: true
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
}
