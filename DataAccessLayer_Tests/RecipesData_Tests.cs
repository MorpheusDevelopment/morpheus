using DataAccessLayer;
using NUnit.Framework;
using Objects;
using Objects.Generics;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer_Tests
{
    [TestFixture, Category("RecipeData Tests")]
    public class RecipesData_Tests
    {
        private RecipeData _target;

        [SetUp]
        public void Setup()
        {
            _target = new RecipeData();

            // This is hackish but beacuse of the fake dal being initalized on first get.
            _target.GetSavedRecipes();
        }

        [Test, Category("RecipeData GetSavedRecipes RetrievesExpected")]
        public async Task RecipeData_GetSavedRecipes_RetrievesExpected()
        {
            var expected = new Recipe { Name = "Peanut Butter Cookies" };

            //Get the list of recipes and make sure expectedis there.
            var savedRecipes = await _target.GetSavedRecipes();
            var actual = savedRecipes.Value.Where(x => x.Name == expected.Name);
            Assert.IsNotEmpty(actual);
        }

        [Test, Category("RecipeData SaveRecipe AddsExpected")]
        public async Task RecipeData_SaveRecipe_AddsExpected()
        {
            //Create and save a new recipe.
            var expected = new Recipe { Name = "New Recipe" };
            await _target.SaveRecipe(expected);

            //Get the list of recipes and make sure it saved as expected.
            var savedRecipes = await _target.GetSavedRecipes();
            var actual = savedRecipes.Value.Where(x => x.Name == expected.Name);

            //Verify the expected recipe is no longer in the list.
            Assert.IsNotEmpty(actual);
        }

        [Test, Category("RecipeData DeleteRecipe RemovesExpected")]
        public async Task RecipeData_DeleteRecipe_RemovesExpected()
        {
            //Create and save a new recipe.
            var expected = new Recipe { Name = "New Recipe" };
            await _target.SaveRecipe(expected);

            //Get the list of recipes and make sure it saved as expected.
            var savedRecipes = await _target.GetSavedRecipes();
            var recipies = savedRecipes.Value.Where(x => x.Name == expected.Name);
            Assert.IsNotEmpty(recipies);

            //Remove the expected recipe and get the updated list.
            await _target.DeleteRecipe(new Id<Recipe>(expected.Id.Value));
            savedRecipes = await _target.GetSavedRecipes();

            //Verify the expected recipe no longer exists.
            Assert.NotNull(savedRecipes);

            var actual = savedRecipes.Value.Where(x => x.Name == expected.Name);
            Assert.IsEmpty(actual);
        }
    }
}
