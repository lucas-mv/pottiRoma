import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { LoginService } from './../shared/services/login.service';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatCardModule } from '@angular/material';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    animations: [routerTransition()]
})

export class LoginComponent implements OnInit {
    constructor(public dialog: MatDialog, public router: Router, private loginService: LoginService, public forms: FormsModule, private toastr: ToastrService) { }

    email: string = '';
    password: string = '';
    loading: boolean = false;

    ngOnInit() {
        if (localStorage.getItem('isLoggedIn')) {
            this.router.navigate(['/main-page']);
        }
    }

    onLoggedin() {
        this.loading = true;
        this.loginService.Login(this.email, this.password)
            .then(response => {
                this.loading = false;
                if (response.message !== '') {
                    this.toastr.error(response.message);
                }
                else {
                    localStorage.setItem('potti-token', response.token);
                    localStorage.setItem('potti-user', JSON.stringify(response.user));
                    localStorage.setItem('isLoggedin', 'true');
                    this.router.navigate(['/main-page']);
                }
            });
    }

    onSignup() {
        this.router.navigate(['/signup']);
    }

    onForgotPassword() : void {
        let dialogRef = this.dialog.open(ForgotPasswordComponent, {
            width: '325px',
        });

        dialogRef.afterClosed().subscribe(result => {
            if(result !== undefined && result !== null){
                this.loading = true;
                this.loginService.ResetPassword(result)
                .then(response => 
                    {
                        this.loading = false;
                        if(response.message === ''){
                            this.toastr.success('Verifique o email inserido para obter a nova senha!');
                        }
                        else{
                            this.toastr.error(response.message);
                        }
                    });
            }
        });
    }
}
