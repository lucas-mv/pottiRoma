import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { LoginService } from './../shared/services/login.service';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',  
    styleUrls: ['./login.component.scss'],
    animations: [routerTransition()]
})

export class LoginComponent implements OnInit {
    constructor(public router: Router, private loginService: LoginService, public forms: FormsModule) {}

    email:string = '';
    password:string = '';

    ngOnInit() {
        if(localStorage.getItem('isLoggedIn')){
            this.router.navigate(['/main-page']);
        }
    }

    onLoggedin() {
        this.loginService.Login(this.email, this.password)
        .then(response => 
          {
              if(response.message !== ''){
                //erro
                debugger;
              }
              else{    
                debugger;
                localStorage.setItem('token', response.token);
                localStorage.setItem('user', response.user);
                localStorage.setItem('isLoggedin', 'true');
                this.router.navigate(['/main-page']);
              }
          });
    }

    onSignup(){
        this.router.navigate(['/signup']);
    }
}
