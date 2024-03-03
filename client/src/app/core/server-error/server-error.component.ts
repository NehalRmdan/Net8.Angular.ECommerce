import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrl: './server-error.component.scss'
})
export class ServerErrorComponent {
 error:any;
 constructor(private _router: Router)
 {
  debugger;
  const navigation= _router.getCurrentNavigation();
  this.error= navigation && navigation.extras &&  navigation.extras.state;
  
 }
}
