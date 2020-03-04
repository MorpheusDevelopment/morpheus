using System.Threading.Tasks;
using BusinessImplementationZone.Interfaces;
using HybridMvcSite.Extenders;
using HybridMvcSite.Factories;
using HybridMvcSite.Models;
using Microsoft.AspNetCore.Mvc;
using Objects;
using Objects.Generics;

namespace HybridMvcSite.Controllers
{
  public class RecipeController : Controller
  {
    private IRecipeRequests _recipeRequestsInterface;
    public IRecipeRequests RecipeRequestsInterface
    {
      get { return _recipeRequestsInterface ?? (_recipeRequestsInterface = RecpieRequestFactory.GetRecipeRequestsInterface()); }
      set { _recipeRequestsInterface = value; }
    }

    [HttpGet]
    public async Task<IActionResult> GetRecipes()
    {
      return Json(await RecipeRequestsInterface.GetSavedRecipes());
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int recipeToDelete)
    {
      return Json(await RecipeRequestsInterface.DeleteRecipe(new Id<Recipe>(recipeToDelete)));
    }

    [HttpPost]
    public async Task<IActionResult> Add(RecipeModel recipeToAdd)
    {
      return Json(await RecipeRequestsInterface.SaveRecipe(recipeToAdd.AsRecipe()));
    }
  }
}
