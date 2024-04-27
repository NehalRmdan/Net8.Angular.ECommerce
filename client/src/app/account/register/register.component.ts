import { Component } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, debounceTime, map, of, switchMap, timer } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  submitted= false;
  registerForm: FormGroup = new FormGroup({
    displayName: new FormControl('', [Validators.required]),
    email: new FormControl(''
    ,[Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]
    ,this.validateEmailNotTaken()),
    password: new FormControl('',[Validators.required]),
  }) ;
  
  returnUrl:string='/shop';
  constructor(private accountService: AccountService, 
    private router : Router,
    private activateRoute : ActivatedRoute)
  {
  }

  ngOnInit(): void {
    this.returnUrl= this.activateRoute.snapshot.queryParams['returnUrl'] || '/shop';
   
  }

  onSubmit()
  {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    this.accountService.register(this.registerForm.value).subscribe({
      next:()=>{
        this.router.navigateByUrl(this.returnUrl);
      },
      error:(err) =>{ console.log(err)}
    });
  
  }

  CreateLoginForm()
  {
    this.registerForm= new FormGroup({
      email: new FormControl('',Validators.required),
      password: new FormControl('',Validators.required),
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.registerForm.controls;
  }

  validateEmailNotTaken(): AsyncValidatorFn {
    return control => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value) {
            return of(null);
          }
          return this.accountService.CheckEmailExists(control.value).pipe(
            map(res => {
               return res ? {emailExists: true} : null;
            })
          );
        })
      )
    }
  }

}
