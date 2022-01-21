import { Component,OnInit,ElementRef, DoCheck } from '@angular/core';
import { FormControl, FormGroup, FormBuilder,Validators, AbstractControl } from '@angular/forms';
import { User } from './model/user';
import { AuthenticationService } from './shared/authentication.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
 
  public islog:boolean;
  title = 'Student';
  username:string="";
  user:User;
  constructor( private authenticationService: AuthenticationService ){

    this.authenticationService.user.subscribe(x => this.user = x);
  }


  loginStatus(){
    this.islog=true;
    this.username=this.user['firstName']
  }


  logout() {
    this.authenticationService.logout();
    this.islog=false;
   
}
 
}
