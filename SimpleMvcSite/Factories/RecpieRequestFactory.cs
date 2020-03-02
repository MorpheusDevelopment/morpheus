using BusinessImplementationZone;
using BusinessImplementationZone.Interfaces;

namespace SimpleMvcSite.Factories
{
    public static class RecpieRequestFactory
    {
        public static IRecipeRequests GetRecipeRequestsInterface() => new RecipeRequests();
    }
}
