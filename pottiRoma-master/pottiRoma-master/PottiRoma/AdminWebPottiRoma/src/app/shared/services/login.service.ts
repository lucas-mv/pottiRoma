import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';

@Injectable()
export class LoginService extends BaseService{

  constructor(private http: Http) {
    super();
   }

   public Login(userName, password) {
    return this.http
      .post(
        this.getBaseUrl() + 'User/Login',
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

  public ResetPassword(email) {
    return this.http
      .post(
        this.getBaseUrl() + 'User/Profile/ResetPasswordByEmail',
        { email: email }
      )
      .toPromise()
      .then(res => {
        let responseJson = res.json();
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
