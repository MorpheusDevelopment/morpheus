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
  public selectedRecipe: RecipeModel;

  public title: string;
  constructor(
    private errorsService: ModalErrorsService,
    private recipeRequests: RecipeRequestsService)
  { }

  public recipeClicked(recipeId: number): void {
    this.selectedRecipe = this.recipes.find(i => i.id === recipeId);
  }

  public addRecipe(): void {

  }

  public editRecipe() : void {

  }

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
