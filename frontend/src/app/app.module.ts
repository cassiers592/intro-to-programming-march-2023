import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MastheadComponent } from './components/masthead/masthead.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavigationComponent } from './components/navigation/navigation.component';

@NgModule({
  declarations: [
    AppComponent,
    MastheadComponent,
    DashboardComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
