using BusinessImplementationZone.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Objects;
using Objects.Generics;
using SimpleMvcSite.Extenders;
using SimpleMvcSite.Factories;
using SimpleMvcSite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMvcSite.Controllers
{
    public class RecipesController : Controller
    {
        private IRecipeRequests _recipeRequestsInterface;
        public IRecipeRequests RecipeRequestsInterface
        {
            get { return _recipeRequestsInterface ?? (_recipeRequestsInterface = RecpieRequestFactory.GetRecipeRequestsInterface()); }
            set { _recipeRequestsInterface = value; }
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await RecipeRequestsInterface.GetSavedRecipes();
            if (!recipes.Successful)
                return Json("There was an error in your request.\n" + string.Join("\n", recipes.Errors.First().Suggestions));

            return View(recipes.Value.Select(x => x.AsRecipeModel()));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int recipeToDelete)
        {
            var result = await RecipeRequestsInterface.DeleteRecipe(new Id<Recipe>(recipeToDelete));
            if (result != null)
                return Json("There was an error in your request.\n" + string.Join("\n", result.Suggestions));

            return Json("Recipe was successfully removed.");
        }

        [HttpPost]
        public async Task<IActionResult> Add(RecipeModel recipeToAdd)
        {
            var result = await RecipeRequestsInterface.SaveRecipe(recipeToAdd.AsRecipe());
            if (result != null)
                return Json("There was an error in your request.\n" + string.Join("\n", result.Suggestions));

            return Json(recipeToAdd.Name + " was successfully " + (recipeToAdd.Id == 0 ? "added" : "updated") + ".");
        }
    }
}