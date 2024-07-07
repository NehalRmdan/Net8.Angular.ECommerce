import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BehaviorSubject, EMPTY, Observable, ReplaySubject, map, of } from 'rxjs';
import { IUser } from '../shared/Models/User';
import { IAddress } from '../shared/Models/Address';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, private router: Router) { }

  baseUrl= environment.apiUrl;
  currentUser= new ReplaySubject<IUser|null>(1);
  user$=this.currentUser.asObservable();
  
  


  loadCurrentUser(token: string | null): Observable<IUser | null> {
    if (token === null) {
      this.currentUser.next(null);
      return of(null);
    }

    let httpHeader: HttpHeaders = new HttpHeaders();
    httpHeader = httpHeader.set('Authorization', `Bearer ${token}`);

    const url = `${this.baseUrl}/api/account/user`;
    return this.http.get<IUser>(url, { headers: httpHeader }).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUser.next(user);
        }
        return user;
      })
    );
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

  CheckEmailExists(email : string)
  {
    let url= this.baseUrl + '/api/account/email-exists?email=' + email;
    return this.http.get<Boolean>(url);
  }

  updateUserAddress(address: IAddress) {
    return this.http.put<IAddress>(this.baseUrl + '/api/account/address', address);
  }

}
