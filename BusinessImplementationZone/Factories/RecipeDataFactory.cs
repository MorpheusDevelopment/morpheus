using DataAccessLayer;
using DataAccessLayer.Interfaces;

namespace BusinessImplementationZone.Factories
{
    public static class RecipeDataFactory
    {
        public static IRecipeData GetRecipeDataInterface() => new RecipeData();
    }
}
