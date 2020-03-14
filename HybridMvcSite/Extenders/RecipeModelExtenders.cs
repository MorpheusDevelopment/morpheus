using Objects;
using Objects.Generics;
using HybridMvcSite.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HybridMvcSite.Extenders
{
    public static class RecipeModelExtenders
    {
        public static RecipeModel AsRecipeModel(this Recipe recipe)
        {
            return recipe == null ? new RecipeModel() :  new RecipeModel
            {
                Id = recipe.Id == null ? 0 : recipe.Id.Value,
                Name = recipe.Name,
                Description = recipe.Description,
                Instructions = recipe.Instructions,
                Ingredients = recipe.Ingredients != null && recipe.Ingredients.Any()
                   ? recipe.Ingredients.Select(x => new IngredientModel
                   {
                       Name = x.Name,
                       Amount = x.Amount,
                       Instrument = ((int)x.Instrument).ToString()
                   }) : new List<IngredientModel>()
            };
        }

        public static Recipe AsRecipe(this RecipeModel recipeModel)
        {
            return recipeModel == null ? new Recipe() : new Recipe
            {
                Id = new Id<Recipe>(recipeModel.Id),
                Name = recipeModel.Name,
                Description = recipeModel.Description,
                Instructions = recipeModel.Instructions,
                Ingredients = recipeModel.Ingredients != null && recipeModel.Ingredients.Any()
                   ? recipeModel.Ingredients.Select(x => new Ingredient
                   {
                       Name = x.Name,
                       Amount = x.Amount,
                       Instrument = (MeasuringType)Enum.Parse(typeof(MeasuringType), x.Instrument),
                   }) : new List<Ingredient>()
            };
        }
    }
}
