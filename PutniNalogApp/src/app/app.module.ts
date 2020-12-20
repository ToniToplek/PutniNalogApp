import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Overlay, ToastrModule } from 'ngx-toastr';
import { appRoutingModule } from './app.routing';
import { AppComponent } from './app.component';
import { PutniNalogComponent } from './putni-nalog/putni-nalog.component';
import { PutniNalogFormComponent } from './putni-nalog/putni-nalog-form/putni-nalog-form.component';
import { HttpClientModule } from '@angular/common/http';
import { OwlDateTimeModule, OwlNativeDateTimeModule} from 'ng-pick-datetime';
import { AdminComponent } from './admin';


@NgModule({ 
  declarations: [
    AppComponent,
    PutniNalogComponent,
    PutniNalogFormComponent,
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
      ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]

})
export class AppModule { }
 