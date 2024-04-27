import { inject } from '@angular/core';
import { CanActivateFn, Router, UrlTree } from '@angular/router';
import { AccountService } from '../../account/account.service';
import { Observable, map } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
 debugger;
  const accountService=inject(AccountService);
  const router= inject(Router);
 
  let exist = true;
  accountService.user$.pipe( map( auth => { 
   exist = auth ? true : false;
   return exist;
  })).subscribe();

return exist? true 
    : inject(Router).navigate(['/login'], {queryParams: {returnUrl: state.url}}); 
};
