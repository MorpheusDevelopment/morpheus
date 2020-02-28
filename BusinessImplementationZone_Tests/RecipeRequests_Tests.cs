using BusinessImplementationZone;
using DataAccessLayer.Interfaces;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BusinessImplementationZone_Tests
{
    [TestFixture, Category("RecipeRequests Tests")]
    public class RecipeRequests_Tests
    {
        private RecipeRequests _target;
        private Mock<IRecipeData> _mockedRecipeDataInterface;

        [SetUp]
        public void SetUp()
        {
            _target = new RecipeRequests();

            _mockedRecipeDataInterface = new Mock<IRecipeData>();
            _target.RecipeDataInterface = _mockedRecipeDataInterface.Object;
        }

        [Test, Category("RecipeRequests Interface RecipeDataInterface")]
        public void RecipeRequests_RecipeDataInterface_NotNull()
        {
            Assert.NotNull(_target.RecipeDataInterface);
        }

        [Test, Category("RecipeRequests Interface RecipeDataInterface")]
        public void RecipeRequests_RecipeDataInterface_SameTwice()
        {
            var recipeDataInterface1 = _target.RecipeDataInterface;
            var recipeDataInterface2 = _target.RecipeDataInterface;
            Assert.AreSame(recipeDataInterface1, recipeDataInterface2);
        }

        [Test, Category("RecipeRequests GetSavedRecipes CallsDal")]
        public async Task RecipeRequests_GetSavedRecipes_CallsDal_Test()
        {
            const int expectedCallCount = 1;
            var actualCallCount = 0;

            _mockedRecipeDataInterface.Setup(x => x.GetSavedRecipes()).Callback(() => actualCallCount++);
            _target.RecipeDataInterface = _mockedRecipeDataInterface.Object;

            await _target.GetSavedRecipes();

            Assert.AreEqual(expectedCallCount, actualCallCount);
        }
    }
}
