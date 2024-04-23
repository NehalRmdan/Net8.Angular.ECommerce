import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent  implements OnInit{

  submitted= false;
  loginForm: FormGroup = new FormGroup({
    email: new FormControl('',[Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
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

    if (this.loginForm.invalid) {
      return;
    }

    this.accountService.login(this.loginForm.value).subscribe({
      next:()=>{
        this.router.navigateByUrl(this.returnUrl);
      },
      error:(err) =>{ console.log(err)}
    });
  
  }

  CreateLoginForm()
  {
    this.loginForm= new FormGroup({
      email: new FormControl('',Validators.required),
      password: new FormControl('',Validators.required),
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }

}
