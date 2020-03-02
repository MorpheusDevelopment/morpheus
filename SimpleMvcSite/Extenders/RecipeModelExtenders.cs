using Objects;
using Objects.Generics;
using SimpleMvcSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMvcSite.Extenders
{
    public static class RecipeModelExtenders
    {
        public static RecipeModel AsRecipeModel(this Recipe recipe)
        {
            return new RecipeModel
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
                       Instrument = (MeasuringTypeModel)((int)x.Instrument)
                   }) : new List<IngredientModel>()
            };
        }

        public static Recipe AsRecipe(this RecipeModel recipeModel)
        {
            return new Recipe
            {
                Id = recipeModel.Id == 0 ? (Id<Recipe>?)null : new Id<Recipe>(recipeModel.Id),
                Name = recipeModel.Name,
                Description = recipeModel.Description,
                Instructions = recipeModel.Instructions,
                Ingredients = recipeModel.Ingredients != null && recipeModel.Ingredients.Any()
                   ? recipeModel.Ingredients.Select(x => new Ingredient
                   {
                       Name = x.Name,
                       Amount = x.Amount,
                       Instrument = (MeasuringType)((int)x.Instrument)
                   }) : new List<Ingredient>()
            };
        }
    }
}
