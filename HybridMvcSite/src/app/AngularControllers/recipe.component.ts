import { Component, OnInit } from '@angular/core';

import { Id } from '../Models/Generics/id';
import { RecipeModel, MeasuringTypeModel, IngredientModel } from '../Models/recipeModels';

//Import services.
import { ModalErrorsService } from '../Services/modal-errors.service';
import { RecipeRequestsService } from '../Services/recipe-requests.service';

@Component({
  selector: 'app-recipes',
  templateUrl: '../AngularTemplates/recipe.component.html',
  styleUrls: ['../AngularStyleSheets/recipe.component.css']
})

export class RecipesComponent implements OnInit {

  measuringTypes: MeasuringTypeModel[] = [
    MeasuringTypeModel.Cup,
    MeasuringTypeModel.Dash
  ];

  public recipes: RecipeModel[];
  public selectedRecipe: RecipeModel;
  public formRecipe: RecipeModel;

  public title: string;
  constructor(
    private errorsService: ModalErrorsService,
    private recipeRequests: RecipeRequestsService)
  { }

  public recipeClicked(recipeId: Id<RecipeModel>): void {
    this.formRecipe = undefined;
    this.selectedRecipe = this.recipes.find(i => i.id === recipeId);
  }

  public addRecipe(): void {
    this.selectedRecipe = undefined;
    this.formRecipe = new RecipeModel();
  }

  public editRecipe(): void {
    this.formRecipe = this.selectedRecipe;
    this.selectedRecipe = undefined;
  }

  public addIngredient(): void {
    this.formRecipe.ingredients.push(new IngredientModel());
  }

  public removeIngredient(ingredientIndexToRemove: number): void {
    this.formRecipe.ingredients.splice(ingredientIndexToRemove, 1);
  }

  public saveRecipe(): void {
    this.recipeRequests.saveRecipe(this.formRecipe)
      .subscribe(
        response => {
          if (response !== undefined && response !== null)
            this.errorsService.addErrorsByError(response)
          else
            window.location.reload();
        },
        err => console.log(err)
      );
  }

  public deleteRecipe(): void {
    this.recipeRequests.deleteRecipe(this.formRecipe.id)
      .subscribe(
        response => {
          if (response !== undefined)
            this.errorsService.addErrorsByError(response)
        },
        err => console.log(err)
      );
  }

  ngOnInit() {
    this.recipes = new Array<RecipeModel>();

    this.recipeRequests.getRecipes()
      .subscribe(
        response => {
          if (response) {
            response.value.forEach(recipe => {
              this.recipes.push(recipe);
            });
          } else {
              this.errorsService.addErrorsByErrorArray(response.errors)
          }
        },
        err => console.log(err)
      );
  }
}
