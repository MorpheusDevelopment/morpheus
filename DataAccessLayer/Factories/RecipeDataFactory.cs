using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Factories
{
    public static class RecipeDataFactory
    {
        public static IRecipeData GetRecipeDataInterface() => new RecipeData();
    }
}
