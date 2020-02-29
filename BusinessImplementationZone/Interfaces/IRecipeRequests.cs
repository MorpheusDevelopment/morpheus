using Objects;
using Objects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessImplementationZone.Interfaces
{
    public interface IRecipeRequests
    {
        Task<IResult<IEnumerable<Recipe>>> GetSavedRecipes();
        Task<IError> SaveRecipe(Recipe recipe);
    }
}
