using BusinessImplementationZone;
using DataAccessLayer.Interfaces;
using Moq;
using NUnit.Framework;
using Objects;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestRepository.Extenders;

namespace BusinessImplementationZone_Tests
{
    [TestFixture, Category("RecipeRequests Tests")]
    public class RecipeRequests_Tests
    {
        private RecipeRequests _target;
        private Mock<IRecipeData> _mockedRecipeDataInterface;
        private Recipe _defaultRecipe = new Recipe {
            Name = "Some Name",
            Ingredients = new List<Ingredient> { new Ingredient() },
            Instructions = "Some Instructions"
        };

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

        [Test, Category("RecipeRequests SaveRecipe DoesntExplodOnNull")]
        public void RecipeRequests_SaveRecipe_DoesntExplodOnNull_Test()
        {
            AssertExtenders.DoesntThrowException(() => _target.SaveRecipe(null));
        }

        [Test, Category("RecipeRequests SaveRecipe CallsDal")]
        public async Task RecipeRequests_SaveRecipe_CallsDal_Test()
        {
            const int expectedCallCount = 1;
            var actualCallCount = 0;

            _mockedRecipeDataInterface.Setup(x => x.SaveRecipe(It.IsAny<Recipe>())).Callback(() => actualCallCount++);
            _target.RecipeDataInterface = _mockedRecipeDataInterface.Object;

            await _target.SaveRecipe(_defaultRecipe);

            Assert.AreEqual(expectedCallCount, actualCallCount);
        }

        [Test, Category("RecipeRequests SaveRecipe CallsDal")]
        public async Task RecipeRequests_SaveRecipe_ReturnExpectedValidationErrors_Test()
        {
            var expected = "Recipe Name can not be blank.";
            _defaultRecipe.Name = string.Empty;
            var result = await _target.SaveRecipe(_defaultRecipe);

            AssertExtenders.ContainsSuggestion(expected, result);
        }
    }
}
