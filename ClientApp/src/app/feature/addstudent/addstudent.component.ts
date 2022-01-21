import {  Component,  OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder,Validators, AbstractControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { addstudentModel } from './addstudent.model';
import { studentApi } from 'src/app/shared/studentApi.service';
import { AppComponent } from 'src/app/app.component';


@Component({
  selector: 'app-addstudent',
  templateUrl: './addstudent.component.html',
  styleUrls: ['./addstudent.component.css']
})

export class  AddstudentComponent implements  OnInit {
 
  submitted = false;
  formValue:FormGroup;
  studentModelobj:addstudentModel = new addstudentModel();
  loginStatus:boolean;


  constructor( private formBuilder: FormBuilder , private api: studentApi,private appComponent:AppComponent ) 
  { 
    this.loginStatus=this.appComponent.islog;
  }

  ngOnInit(): void {
    this.formValue=this.formBuilder.group({
      firstName: ['',[ Validators.required,Validators.pattern('[a-zA-Z ]*')]  ],
      lastName: ['',[  Validators.required , Validators.pattern('[a-zA-Z ]*')]],
      salary: ['' ],
      gender:['' ]
    });
  } 

  postStudentDetails(){
    this.studentModelobj.firstName=this.formValue.controls['firstName'].value;
    this.studentModelobj.lastName=this.formValue.controls['lastName'].value;
    this.studentModelobj.salary=this.formValue.controls['salary'].value;
    this.studentModelobj.gender =this.formValue.controls['gender'].value;

    this.api.postStudent(this.studentModelobj).subscribe(result=>{
      alert("Student Record Added successfuly !")
      this.submitted=false;
      this.formValue.reset();
    },
    err=>{
      alert("Something Went wrong !!!!")
    }) 
  }

  onSubmit(): void {
    if (this.loginStatus)
    {
      this.submitted = true;
      if (this.formValue.invalid) {
      return;
      }
      this.postStudentDetails();  
    }
    else
    {
      alert("Please Login First")
    }
         
  }


}
