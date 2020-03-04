using BusinessImplementationZone;
using BusinessImplementationZone.Interfaces;

namespace HybridMvcSite.Factories
{
  public static class RecpieRequestFactory
  {
    public static IRecipeRequests GetRecipeRequestsInterface() => new RecipeRequests();
  }
}
