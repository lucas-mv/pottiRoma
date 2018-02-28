import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';

@NgModule({
    imports: [CommonModule, LoginRoutingModule, MatButtonModule, MatCheckboxModule],
    exports: [MatButtonModule, MatCheckboxModule],
    declarations: [LoginComponent]
})
export class LoginModule {}
