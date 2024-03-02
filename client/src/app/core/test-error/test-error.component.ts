import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrl: './test-error.component.scss'
})
export class TestErrorComponent implements OnInit{
  baseUrl= environment.apiUrl;
  constructor(private _http: HttpClient)
  {}

  ngOnInit(): void {
  }

  get404Err()
  {
    let url= this.baseUrl+ 'production/42';
    this._http.get(url).subscribe({
      next: r => { console.log(r);},
      error: e=>{ console.log(e);}
    })
  }

  get500Err()
  {
    let url= this.baseUrl+ 'api/buggy/server-error';
    this._http.get(url).subscribe({
      next: r => { console.log(r);},
      error: e=>{ console.log(e);}
    })
  }

  get400Err() 
  {
    let url= this.baseUrl+ 'api/buggy/bad-request';
    this._http.get(url).subscribe({
      next: r => { console.log(r);},
      error: e=>{ console.log(e);}
    })
  }

  get400ValidationErr()
  {
    let url= this.baseUrl+ 'product/forty-two';
    this._http.get(url).subscribe({
      next: r => { console.log(r);},
      error: e=>{ console.log(e);}
    })
  }
}
