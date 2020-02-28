using DataAccessLayer.Interfaces;
using Objects;
using Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RecipeData : IRecipeData
    {
        public Task<IResult<IEnumerable<Recipe>>> GetSavedRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
