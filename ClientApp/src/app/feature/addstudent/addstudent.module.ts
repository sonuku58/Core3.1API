import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddstudentRoutingModule } from './addstudent-routing.module';
import { AddstudentComponent } from './addstudent.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddstudentComponent
  ],
  imports: [
    CommonModule,
    AddstudentRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AddstudentModule { }
