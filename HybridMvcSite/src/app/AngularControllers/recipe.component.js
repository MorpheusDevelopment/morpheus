import { __decorate } from "tslib";
import { Component } from '@angular/core';
let RecipesComponent = class RecipesComponent {
    constructor(errorsService, recipeRequests) {
        this.errorsService = errorsService;
        this.recipeRequests = recipeRequests;
    }
    ngOnInit() {
        this.recipes = new Array();
        this.recipeRequests.getRecipes()
            .subscribe(response => {
            if (response) {
                response.value.forEach(email => {
                    this.recipes.push(email);
                });
            }
            else {
                this.errorsService.addErrorsByErrorArray(response.errors);
            }
        }, err => console.log(err));
    }
};
RecipesComponent = __decorate([
    Component({
        selector: 'app-recipes',
        templateUrl: '../AngularTemplates/recipe.component.html',
        styleUrls: ['../AngularStyleSheets/recipe.component.css']
    })
], RecipesComponent);
export { RecipesComponent };
//# sourceMappingURL=recipe.component.js.map