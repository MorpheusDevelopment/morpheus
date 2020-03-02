using BusinessImplementationZone.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSite.Factories;

namespace SimpleMvcSite.Controllers
{
    public class RecipesController : Controller
    {
        private IRecipeRequests _recipeRequestsInterface;
        public IRecipeRequests RecipeDataInterface
        {
            get { return _recipeRequestsInterface ?? (_recipeRequestsInterface = RecpieRequestFactory.GetRecipeRequestsInterface()); }
            set { _recipeRequestsInterface = value; }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}