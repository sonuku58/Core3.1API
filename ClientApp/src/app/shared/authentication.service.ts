import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../model/user'; 

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private userSubject: BehaviorSubject<User>;
    private usermodel:User;
    public user: Observable<User>;
    public name:string;

    constructor( private router: Router,private http: HttpClient) 
    {
        this.userSubject = new BehaviorSubject<User>(this.usermodel);
        this.user = this.userSubject.asObservable();
    }

    public get userValue(): User {
        return this.userSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<any>(`${environment.apiUrl}/user/authenticate`, { username, password })
            .pipe(map(user => {
                this.userSubject.next(user); 
                return user;
            }));
    }

    logout() {
        this.userSubject.next(null);
        this.router.navigate(['/login']);
    }
}