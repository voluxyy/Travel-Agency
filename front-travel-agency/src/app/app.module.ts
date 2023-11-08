import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { DestinationComponent } from './destination/destination.component';

@NgModule({
  declarations: [
    AppComponent,
    DestinationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      //{path: '', component: ComponentName},
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
