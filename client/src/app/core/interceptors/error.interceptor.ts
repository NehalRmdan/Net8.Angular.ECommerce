import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { NavigationExtras, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable, catchError, delay, throwError } from "rxjs";

@Injectable()
 export class ErrorInterceptor implements HttpInterceptor {

  constructor(private _router : Router, private toastr: ToastrService)
  {

  }
  
  intercept(req: HttpRequest<any>, handler: HttpHandler): Observable<HttpEvent<any>> {
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
              if(error.status === 400 || error.status === 401)
              {
                if(error.error.errors){
                  throw error.error;
                }
                else
                  this.toastr.error(error.error.message, error.error.statusCode)
              }
              else if(error.status === 404)
                this._router.navigate(['/not-found'])
              else if(error.status === 500)
              {
                const navigationExtra:NavigationExtras={state: error.error};
                 this._router.navigateByUrl('/server-error',navigationExtra);
              }

          }
          return throwError(() => new Error(errorMsg));
      })
  )
  }
}