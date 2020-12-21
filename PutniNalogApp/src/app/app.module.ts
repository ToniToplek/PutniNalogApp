import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Overlay, ToastrModule } from 'ngx-toastr';
import { appRoutingModule } from './app.routing';
import { AppComponent } from './app.component';
import { PutniNalogComponent } from './putni-nalog/putni-nalog.component';

import { HttpClientModule } from '@angular/common/http';
import { OwlDateTimeModule, OwlNativeDateTimeModule} from 'ng-pick-datetime';
import { AdminComponent } from './admin';



@NgModule({ 
  declarations: [
    AppComponent,
    PutniNalogComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,  
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    appRoutingModule ,
    ReactiveFormsModule,

      ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]

})
export class AppModule { }
 