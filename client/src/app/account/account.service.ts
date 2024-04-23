import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BehaviorSubject, EMPTY, Observable, map, of } from 'rxjs';
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
  
  getCurrentUser()
  {
    return this.currentUser.value;
  }

  loadCurrentUser(token : string | null)
  {
    if(token == null)
      { 
        this.currentUser.next(null);
        return EMPTY;
      }

    let httpHeader:HttpHeaders = new HttpHeaders();
    httpHeader=httpHeader.set('authorization',`Bearer ${token}`);

    let url= this.baseUrl + '/api/account/user';
    return this.http.get<IUser>(url,{ headers: httpHeader}).pipe(
      map((user: IUser) =>{
        if(user)
          {
        localStorage.setItem("token",user.token);
        this.currentUser.next(user);
          }
      
      })) 
  }

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
    localStorage.removeItem("token");
    this.router.navigateByUrl('/');
  }

}
