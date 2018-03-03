import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';

@Injectable()
export class SalesReportService extends BaseService{

  constructor(private http: Http) {
    super();
   }

   public getAllSales(){
    return this.http
    .post(
      this.getBaseUrl() + 'Sales/GetAllSales',
      null,
      this.createAuthenticationRequestOptions()
    )
    .toPromise()
    .then(res => {
      let responseJson = res.json();
      return {
        sales: responseJson,
        message: ''
      };
    })
    .catch(res => {
      return {
        sales: null,
        message: res._body
      }
    });
   }

   public generateSalesReport(){
    return this.http
      .get(
        this.getBaseUrl() + 'Sales/Report',
        this.createBlobAuthenticationRequestOptions()
      )
      .toPromise()
      .then(res => {        
        let date = new Date();
        let fileName = 'RelatorioVendas_' + date.getDate() + '-' + (date.getMonth()+1) + '-' + date.getFullYear() + '.xlsx';
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
