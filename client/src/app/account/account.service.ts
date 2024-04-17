import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { IUser } from '../shared/Models/User';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, private router: Router) { }

  baseUrl= environment.apiUrl;
  currentUser= new BehaviorSubject<IUser|null>(null);
  user$=this.currentUser.asObservable();
  
  login(values: any)
  {
    let url= this.baseUrl +"/api/account/login";
    return  this.http.post<IUser>(url,values).pipe(
      map((user: IUser) =>{
        localStorage.setItem("token",user.token);
        this.currentUser.next(user);
      }
      )
    );
  }

  register(values: any)
  {
    let url= this.baseUrl +"/api/account/register";
    return this.http.post(url,values).pipe(
      map((user: any) =>{
        this.currentUser.next(user);
        localStorage.setItem("token",user.token);
      }
      )
    );
  }

  logOut()
  {
    this.currentUser.next(null);
    localStorage.removeItem("usr");
    this.router.navigateByUrl('/');
  }

}
