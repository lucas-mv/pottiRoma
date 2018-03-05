import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, ResponseContentType  } from '@angular/http';
import { saveAs } from 'file-saver';

@Injectable()
export class BaseService {

  constructor() { }

  protected getBaseUrl(){
    return 'http://localhost:51945/api/v1/';
    // return 'https://pottiroma.azurewebsites.net/api/v1/;
  }

  protected createAuthenticationRequestOptions(){
    let user = JSON.parse(localStorage.getItem('potti-user'));
    let token =localStorage.getItem('potti-token');
    let headers = new Headers();
    headers.append('user', user.UsuarioId);
    headers.append('Authorization', 'bearer ' + token);
    let opts = new RequestOptions();
    opts.headers = headers;
    return opts;
  }

  protected createBlobAuthenticationRequestOptions(){
    let user = JSON.parse(localStorage.getItem('potti-user'));
    let token =localStorage.getItem('potti-token');
    let headers = new Headers();
    headers.append('user', user.UsuarioId);
    headers.append('Authorization', 'bearer ' + token);
    let opts = new RequestOptions();
    opts.headers = headers;
    opts.responseType = ResponseContentType.Blob;
    return opts;
  }

  protected saveAsBlob(data: any, fileName:string) {
    const blob = new Blob([data._body],
        { type: 'application/vnd.ms-excel' });
    const file = new File([blob], fileName,
        { type: 'application/vnd.ms-excel' });

    saveAs(file);
  }
}
