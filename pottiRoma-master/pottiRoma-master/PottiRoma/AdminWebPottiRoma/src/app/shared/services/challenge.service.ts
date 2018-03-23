import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';

@Injectable()
export class ChallengeService  extends BaseService {

    constructor(private http: Http) {
        super();
    }

    public getCurrentChallenges() {
        return this.http
            .get(
            this.getBaseUrl() + 'Challenge/GetChallengesPortal',
            this.createAuthenticationRequestOptions()
            )
            .toPromise()
            .then(res => {
                let responseJson = res.json();
                return {
                    challenges: responseJson.Challenges,
                    message: ''
                };
            })
            .catch(res => {
                return {
                    challenges: null,
                    message: res._body
                }
            });
    }

    public UpdateChallenge(request:any) {
        return this.http
            .post(
            this.getBaseUrl() + 'Challenge/Update',
            request,
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
}
