using DataAccessLayer;
using NUnit.Framework;
using Objects;
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
    }
}
