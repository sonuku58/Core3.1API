import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShowRoutingModule } from './show-routing.module';
import { ShowComponent } from './show.component';
import { studentApi } from 'src/app/shared/studentApi.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { nameFilterPipe } from './nameFilter.pipe';




@NgModule({
  declarations: [
    ShowComponent,
    nameFilterPipe
  ],
  imports: [
    CommonModule,
    ShowRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ShowModule { }
