import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { NavigationExtras, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable, catchError, delay, finalize, throwError } from "rxjs";
import { BusyService } from "../services/busy.service";

@Injectable()
 export class LoadingInterceptor implements HttpInterceptor {

  constructor(private busyService: BusyService)
  {

  }
  
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    if(req.url.includes('email-exists'))
      {
        return next.handle(req);
      }

    this.busyService.busy();
    return next.handle(req).pipe(
      delay(1000),
      finalize(() =>{
        this.busyService.idle();
      })
  )
  }
}