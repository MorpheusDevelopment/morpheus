using Objects;
using Objects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRecipeData
    {
        Task<IResult<IEnumerable<Recipe>>> GetSavedRecipes();
    }
}
