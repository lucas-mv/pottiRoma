import { Injectable } from '@angular/core';
// import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Http } from '@angular/http';


@Injectable()
export class LoginService {

  constructor(private http: Http) { }

  Login(userName, password) {
    return this.http
      .post(
        'http://localhost:51945/api/v1/User/Login',
        // 'https://pottiroma.azurewebsites.net/api/v1/User/Login',
        {
          Email: userName,
          Password: password,
          Origin: 1
        }
      )
      .toPromise()
      .then(res => {
        let responseJson = res.json();
        return {
          token: responseJson.Token,
          user: responseJson.User,
          message: ''
        };
      })
      .catch(res => {
        return {
          token: '',
          user: null,
          message: res._body
        }
      });
  }
}
