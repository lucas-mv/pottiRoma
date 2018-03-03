import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions  } from '@angular/http';

@Injectable()
export class BaseService {

  constructor() { }

  createAuthenticationRequestOptions(){
    let user = JSON.parse(localStorage.getItem('potti-user'));
    let token =localStorage.getItem('potti-token');
    let headers = new Headers();
    headers.append('user', user.UsuarioId);
    headers.append('Authorization', 'bearer ' + token);
    let opts = new RequestOptions();
    opts.headers = headers;
    return opts;
  }
}
