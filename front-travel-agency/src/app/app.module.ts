import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { DestinationPageComponent } from './components/destination-page/destination-page.component';
import { UserComponent } from './components/user/user.component';
import { ErrorPageComponent } from './components/error-page/error-page.component';
import { CategoryPageComponent } from './components/category-page/category-page.component';
import { HomeComponent } from './components/home/home.component';
import { DatabaseComponent } from './components/database/database.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DestinationPageComponent,
    UserComponent,
    ErrorPageComponent,
    CategoryPageComponent,
    HomeComponent,
    DatabaseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent},
      {path: 'database', component: DatabaseComponent},
      {path: 'destination/:id', component: DestinationPageComponent},
      {path: 'categorie/:id', component: CategoryPageComponent},
      {path: 'user', component: UserComponent},
      {path: '**', component: ErrorPageComponent}
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
