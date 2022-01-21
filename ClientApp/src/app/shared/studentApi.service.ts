import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DoCheck, Injectable, OnChanges, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../model/user';
import { AuthenticationService } from './authentication.service';
 
@Injectable({
  providedIn: 'root'
})
export class studentApi {

  private reqHeader:HttpHeaders
  user:User;

  constructor( private http: HttpClient ,  private authenticationService: AuthenticationService )
   {
    this.authenticationService.user.subscribe(x => this.user = x);
    }

  postStudent(data:any)
  {
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + this.user['token']
   });
    return this.http.post<any>('https://localhost:5001/student',data,{headers:reqHeader}).pipe(map((res:any) => {
      return res;
    }))
  }

  updateStudent(id:number,data:any)
  {
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + this.user['token']
   });
    return this.http.put<any>('https://localhost:5001/student/'+id,data,{headers:reqHeader}).pipe(map((res:any)=>
    {
      return res;
    }))
  }


  getStudent()
  {
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + this.user['token']
   });
       return this.http.get<User>('https://localhost:5001/student',{headers:reqHeader}).pipe(map((res:any)=>
     {
     return res;
     }))
  }
  

 deleteStudent(id:number)
 {

  var reqHeader = new HttpHeaders({ 
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + this.user['token']
 });
   return this.http.delete<any>('https://localhost:5001/student/'+id,{headers:reqHeader}).pipe(map((res:any)=>
   {
     return res;
   }))

 }


}
