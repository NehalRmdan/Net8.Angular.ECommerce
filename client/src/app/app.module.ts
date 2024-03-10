import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './core/nav-bar/nav-bar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';
import { CoreModule } from './core/core.module';
import { ShopComponent } from './shop/shop.component';
import { ShopModule } from './shop/shop.module';
import { HomeModule } from './home/home.module';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './core/interceptors/loading.interceptors';
import { NgxCarouselModule } from 'ngx-carousel/src/ngx-carousel.module';
import { CarouselModule } from 'ngx-owl-carousel-o';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(
      {
        positionClass: 'toast-bottom-right',
        preventDuplicates : true
      }
    ), 
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
    // ToastrModule added,
    CoreModule,
    HomeModule
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient(withFetch()),
    [
      provideHttpClient(
        // DI-based interceptors must be explicitly enabled.
        withInterceptorsFromDi(),
      ),
      {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
    ],
    [
      provideHttpClient(
        // DI-based interceptors must be explicitly enabled.
        withInterceptorsFromDi(),
      ),
      {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
    ]
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
