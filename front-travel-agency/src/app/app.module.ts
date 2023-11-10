import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { DestinationPageComponent } from './destination-page/destination-page.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { CategoryPageComponent } from './category-page/category-page.component';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DestinationPageComponent,
    ProfilePageComponent,
    ErrorPageComponent,
    CategoryPageComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent},
      {path: 'destination/:id', component: DestinationPageComponent},
      {path: 'categorie/:id', component: CategoryPageComponent},
      {path: 'profile/:id', component: ProfilePageComponent},
      {path: '**', component: ErrorPageComponent}
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
