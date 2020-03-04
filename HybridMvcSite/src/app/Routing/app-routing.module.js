import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
//Includes for default/base pages.
import { DefaultComponent } from '../AngularControllers/_default.component';
//Includes for project pages.
import { RecipesComponent } from '../AngularControllers/recipe.component';
//Includes for Error pages.
import { ErrorsPageNotFoundComponent } from '../AngularControllers/errors-page-not-found.component';
const routes = [
    //Routes for default/base pages.
    { path: '', component: DefaultComponent },
    {
        path: "Recipes", children: [
            { path: '', component: RecipesComponent }
        ]
    },
    //Catch all route.
    { path: '**', component: ErrorsPageNotFoundComponent }
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = __decorate([
    NgModule({
        imports: [RouterModule.forRoot(routes)],
        exports: [RouterModule]
    })
], AppRoutingModule);
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map