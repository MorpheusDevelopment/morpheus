import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './Modules/material.module'
import { AppRoutingModule } from './Routing/app-routing.module';
import { AppComponent } from './app.component';


//Includes for default/base pages.
import { DefaultComponent } from './AngularControllers/_default.component';

//Includes for project pages.
import { RecipesComponent } from './AngularControllers/recipe.component';

//Includes for Error pages.
import { ErrorsPageNotFoundComponent } from './AngularControllers/errors-page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,

    DefaultComponent,
    RecipesComponent,
    ErrorsPageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
