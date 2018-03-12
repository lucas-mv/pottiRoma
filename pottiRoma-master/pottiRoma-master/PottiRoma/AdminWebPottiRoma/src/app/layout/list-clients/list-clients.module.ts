import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { ListClientsRoutingModule } from './list-clients-routing.module';
import { ListClientsComponent } from './list-clients.component';
import { PageHeaderModule } from './../../shared';
import { LoadingModule } from 'ngx-loading';

@NgModule({
    imports: [CommonModule, ListClientsRoutingModule, PageHeaderModule, LoadingModule, MatButtonModule, MatCheckboxModule],
    declarations: [ListClientsComponent]
})
export class ListClientsModule {}
