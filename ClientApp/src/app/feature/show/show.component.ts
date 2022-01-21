import {  Component ,OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder,Validators, AbstractControl } from '@angular/forms';
import { AppComponent } from 'src/app/app.component';
import { User } from 'src/app/model/user';
import { AuthenticationService } from 'src/app/shared/authentication.service';
import {studentApi } from 'src/app/shared/studentApi.service';
import { addstudentModel } from '../addstudent/addstudent.model';



@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements  OnInit {
 
  allStudent:any;
  formValue:FormGroup;
  nameSearch:string;
  studentdata:addstudentModel=new addstudentModel();
  loginStatus:boolean;
  user:User;

  constructor( private api: studentApi,private formBuilder:FormBuilder,  private appcomp:AppComponent,private authenticationService: AuthenticationService ) {
    this.loginStatus=this.appcomp.islog;
    this.authenticationService.user.subscribe(x => this.user = x);
   }


  ngOnInit(): void {
    this.formValue=this.formBuilder.group({
      firstName: ['',[ Validators.required,Validators.pattern('[a-zA-Z ]*')]  ],
      lastName: ['',[  Validators.required , Validators.pattern('[a-zA-Z ]*')]],
      salary:[''],
      gender:['' ]
    });
    this.getAllStudents();
  }

  
getAllStudents(){
  if(this.loginStatus)
  {
    this.api.getStudent().subscribe(res=>{
      this.allStudent=res;
    })
  }
  else{
    this.allStudent=null;
  }
   
  }

onEdit(value:any){
    this.studentdata.id=value.id;
    this.formValue.controls['firstName'].setValue(value.firstName);
    this.formValue.controls['lastName'].setValue(value.lastName);
    this.formValue.controls['salary'].setValue(value.salary);
    this.formValue.controls['gender'].setValue(value.gender); 
}

updateStudentDetails()
{
   if(this.user['role']=='Admin')
   { 
      if(this.formValue.valid)
      {  
          this.studentdata.firstName=this.formValue.value.firstName;
          this.studentdata.lastName=this.formValue.value.lastName;
          this.studentdata.salary=this.formValue.value.salary;
          this.studentdata.gender=this.formValue.value.gender;
            this.api.updateStudent(this.studentdata.id,this.studentdata).subscribe(result=>{      
              alert("Student Record Updated successfuly !")
              this.getAllStudents();
            }
            )
      }
      else
      {
        alert("please enter correct data")
      }
    }
    else
    {
      alert("Only Admin can Update this")
    }

  }

deleteStudentDetail(data:any)
{
  if(this.user['role']=='Admin')
  {
    this.api.deleteStudent(data.id).subscribe(res=>{
      this.getAllStudents();
    })
  }
  else
  {
    alert("Only Admin can do this")
  }
    
 
}


}
