using System.Collections.Generic;
using System.Linq;
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
      var result = await RecipeRequestsInterface.GetSavedRecipes();
      if (!result.Successful)
        return Json(result);
      return Json(new Result<IEnumerable<RecipeModel>> { Value = result.Value.Select(x => x.AsRecipeModel()) });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int recipeToDelete)
    {
      return Json(await RecipeRequestsInterface.DeleteRecipe(new Id<Recipe>(recipeToDelete)));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody]RecipeModel recipeToAdd)
    {
      return Json(await RecipeRequestsInterface.SaveRecipe(recipeToAdd.AsRecipe()));
    }
  }
}
