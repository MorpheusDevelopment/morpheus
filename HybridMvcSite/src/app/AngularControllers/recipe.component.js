import { __decorate } from "tslib";
import { Component } from '@angular/core';
let RecipesComponent = class RecipesComponent {
    constructor() { }
    ngOnInit() {
        this.title = 'Recipes';
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