import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';

@Injectable()
export class ClientsService extends BaseService{

  constructor(private http:Http) {
    super();
   }

   public getAllClients(){
    return this.http
    .get(
      this.getBaseUrl() + 'Clients/Get',
      this.createAuthenticationRequestOptions()
    )
    .toPromise()
    .then(res => {
      let responseJson = res.json();
      debugger;
      return {
        clients: responseJson.Clients,
        message: ''
      };
    })
    .catch(res => {
      return {
        clients: null,
        message: res._body
      }
    });
   }

   public generateClientsReport(){
    return this.http
      .get(
        this.getBaseUrl() + 'Clients/Report',
        this.createBlobAuthenticationRequestOptions()
      )
      .toPromise()
      .then(res => {
        let date = new Date();
        let fileName = 'RelatorioClientes_' + date.getDate() + '-' + (date.getMonth()+1) + '-' + date.getFullYear() + '.xlsx';
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
