import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule, MatNativeDateModule, MatDatepickerModule, MatSelectModule   } from '@angular/material';
import { MAT_DATE_LOCALE  } from '@angular/material/core';
import { MaterialModule } from './material.module';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import {Component} from '@angular/core';
import { MatCardModule } from '@angular/material';
import { MatDialogModule } from '@angular/material';
import {MatRadioModule} from '@angular/material/radio';

import { BaseService } from './shared/services/base.service';
import { LoginService } from './shared/services/login.service';
import { SalespersonService } from './shared/services/salesperson.service';
import { SalesReportService } from './shared/services/sales-report.service';
import { ClientsService } from './shared/services/clients.service';
import { GamificationService } from './shared/services/gamification.service';
import { SeasonService } from './shared/services/season.service';
import { ChallengeService } from './shared/services/challenge.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthGuard } from './shared';

import { ToastrModule } from 'ngx-toastr';
import { LoadingModule } from 'ngx-loading';



// AoT requires an exported function for factories
export function createTranslateLoader(http: HttpClient) {
    // for development
    // return new TranslateHttpLoader(http, '/start-angular/SB-Admin-BS4-Angular-5/master/dist/assets/i18n/', '.json');
    return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
    imports: [
        HttpModule,
        CommonModule,
        BrowserModule,
        FormsModule,
        BrowserAnimationsModule,
        HttpClientModule,
        ToastrModule.forRoot(),
        LoadingModule,
        MatFormFieldModule,
        MatInputModule,
        MatNativeDateModule, 
        MatDatepickerModule,
        MatAutocompleteModule,
        MatCardModule,
        MatSelectModule,
        MatRadioModule,
        MatDialogModule,
        MaterialModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: createTranslateLoader,
                deps: [HttpClient]
            }
        }),
        AppRoutingModule
    ],
    declarations: [AppComponent],
    providers: [
        AuthGuard,
        BaseService,
        LoginService,
        SalespersonService,
        SalesReportService,
        ClientsService,
        GamificationService,
        SeasonService,
        ChallengeService,
        {provide: MAT_DATE_LOCALE, useValue: 'pt-BR'}
    ],
    bootstrap: [AppComponent]
})
export class AppModule {}
