using BusinessImplementationZone.Interfaces;
using Objects;
using Objects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessImplementationZone
{
    public class RecipeRequests : IRecipeRequests
    {
        public Task<IResult<IEnumerable<Recipe>>> GetSavedRecipes()
        {
            throw new System.NotImplementedException();
        }
    }
}
