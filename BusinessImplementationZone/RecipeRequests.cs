using BusinessImplementationZone.Interfaces;
using DataAccessLayer.Factories;
using DataAccessLayer.Interfaces;
using Objects;
using Objects.Interfaces;
using System.Collections.Generic;
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
    }
}
