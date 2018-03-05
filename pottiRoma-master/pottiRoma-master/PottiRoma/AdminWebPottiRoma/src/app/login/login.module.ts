import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { LoadingModule } from 'ngx-loading';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { MatCardModule } from '@angular/material';

@NgModule({
    imports: [CommonModule, 
                LoginRoutingModule, 
                MatButtonModule, 
                MatCheckboxModule, 
                FormsModule,  
                LoadingModule,
                MatFormFieldModule,
                MatInputModule,
                MatCardModule],
    exports: [MatButtonModule, MatCheckboxModule],
    declarations: [LoginComponent]
})
export class LoginModule {}
