import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, catchError, throwError } from "rxjs";

@Injectable()
 export class ErrorInterceptor implements HttpInterceptor {

  constructor(private _router : Router)
  {

  }
  
  intercept(req: HttpRequest<any>, handler: HttpHandler): Observable<HttpEvent<any>> {
    console.log('Request URL: ' + req.url);
    return handler.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        debugger;
          let errorMsg = '';
          if (error.error instanceof ErrorEvent) {
              console.log('This is client side error');
              errorMsg = `Error: ${error.error.message}`;
          } else {
              console.log('This is server side error');
              errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
              if(error.status == 404)
                this._router.navigate(['/not-found'])
              else if(error.status === 500)
                 this._router.navigate(['/server-error'])

          }
          console.log(errorMsg);
          return throwError(() => new Error(errorMsg));
      })
  )
  }
}