import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, delay, finalize, throwError } from "rxjs";
import { BusyService } from "../services/busy.service";

@Injectable()
 export class TokenInterceptor implements HttpInterceptor {

  constructor(private busyService: BusyService)
  {

  }
  
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token= localStorage.getItem('token');
    if(token)
        {
            req = req.clone({
                setHeaders: {
                  Authorization: `Bearer ${token}`,
                },
              });
        }
    
    return next.handle(req);
  }
}