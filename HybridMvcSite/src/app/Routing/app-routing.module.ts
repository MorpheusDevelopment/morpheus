import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//Includes for default/base pages.
import { DefaultComponent } from '../AngularControllers/_default.component';

//Includes for project pages.
import { RecipesComponent } from '../AngularControllers/recipe.component';

const routes: Routes = [

  //Routes for default/base pages.
  { path: '', component: DefaultComponent },

  {
    path: "Recipes", children: [
      { path: '', component: RecipesComponent }
    ]
  }

  //Catch all route.
  { path: '**', component: ErrorsPageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
