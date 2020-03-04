import { Component, OnInit } from '@angular/core';

import { RecipeModel } from '../Models/recipeModels';

//Import services.
import { ModalErrorsService } from '../Services/modal-errors.service';
import { RecipeRequestsService } from '../Services/recipe-requests.service';

@Component({
  selector: 'app-recipes',
  templateUrl: '../AngularTemplates/recipe.component.html',
  styleUrls: ['../AngularStyleSheets/recipe.component.css']
})

export class RecipesComponent implements OnInit {

  public recipes: RecipeModel[];

  public title: string;
  constructor(
    private errorsService: ModalErrorsService,
    private recipeRequests: RecipeRequestsService)
  { }

  ngOnInit() {
    this.recipes = new Array<RecipeModel>();

    this.recipeRequests.getRecipes()
      .subscribe(
        response => {
          if (response) {
            response.value.forEach(email => {
              this.recipes.push(email);
            });
          } else {
              this.errorsService.addErrorsByErrorArray(response.errors)
          }
        },
        err => console.log(err)
      );
  }
}
