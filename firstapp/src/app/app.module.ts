import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent} from './app.component';
import { ViewComponent } from './view/view.component';
import { UserdetailsComponent } from './userdetails/userdetails.component';
import { Routes,RouterModule } from '@angular/router';

const appRoute:Routes=[
  {path:'',component:UserdetailsComponent},
  {path:'view',component:ViewComponent},
  
]

@NgModule({
  declarations: [
    AppComponent,
    ViewComponent,
    UserdetailsComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoute)
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
