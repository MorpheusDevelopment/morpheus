using BusinessImplementationZone.Interfaces;
using DataAccessLayer.Factories;
using DataAccessLayer.Interfaces;
using Objects;
using Objects.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessImplementationZone
{
    public class RecipeRequests : IRecipeRequests
    {
        private IRecipeData _recipeDataInterface;
        public IRecipeData RecipeDataInterface
        {
            get { return _recipeDataInterface ?? (_recipeDataInterface = RecipeDataFactory.GetRecipeDataInterface()); }
            set { _recipeDataInterface = value; }
        }

        public async Task<IResult<IEnumerable<Recipe>>> GetSavedRecipes()
        {
            return await RecipeDataInterface.GetSavedRecipes();
        }

        public async Task<IError> SaveRecipe(Recipe recipe)
        {
            var validationMessages = new List<string>();
            if (recipe == null)
                return new Error { ErrorMessage = "Validation Failed", Suggestions = new List<string> { "Recipe can't be empty." } };
            if (string.IsNullOrEmpty(recipe.Name))
                validationMessages.Add("Recipe Name can not be blank.");
            if (string.IsNullOrEmpty(recipe.Instructions))
                validationMessages.Add("Recipe Instructions can not be blank.");
            if (!recipe.Ingredients.Any())
                validationMessages.Add("Recipe must have at least one ingredient.");

            if (validationMessages.Any())
                return new Error { ErrorMessage = "Validation Failed", Suggestions = validationMessages };

            return await RecipeDataInterface.SaveRecipe(recipe);
        }
    }
}
