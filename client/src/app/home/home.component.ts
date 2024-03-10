import { Component } from '@angular/core';
import { CarouselConfig } from 'ngx-bootstrap/carousel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [
    { provide: CarouselConfig, useValue: { interval: 9000, noPause: false, showIndicators: true } }
 ],
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  slides = [
    {image: 'assets/images/hero1.jpg', text: 'First'},
    {image: 'assets/images/hero2.jpg',text: 'Second'},
    {image: 'assets/images/hero3.jpg',text: 'Third'}
 ];

 noWrapSlides = false;
 showIndicator = true;

}
