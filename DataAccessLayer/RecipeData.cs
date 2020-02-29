using DataAccessLayer.Interfaces;
using Objects;
using Objects.Generics;
using Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RecipeData : IRecipeData
    {
        private static IList<Recipe> _mockedDataSource;

        private static IList<string> _dataConnectionUnavailable =
            new List<string> { "The remote connection is currently unavailable.", "Please check you connection and try again." };

        private IList<Recipe> InitRecipeList()
        {
            return new List<Recipe> {
                new Recipe
                {
                    Id = new Id<Recipe>(1),
                    Name = "Peanut Butter Cookies",
                    Description = "A simple recipe for making Peanut Butter Cookies, 15 minute prep-time.",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient{ Name = "Softened Margarine or Butter", Instrument = MeasuringType.Cup, Amount = 0.5 },
                        new Ingredient{ Name = "Flour", Instrument = MeasuringType.Cup, Amount = 1.25 },
                        new Ingredient{ Name = "Peanut Butter", Instrument = MeasuringType.Cup, Amount = 0.5 },
                        new Ingredient{ Name = "Baking Powder", Instrument = MeasuringType.Teaspoon, Amount = 0.5 },
                        new Ingredient{ Name = "Sugar", Instrument = MeasuringType.Cup, Amount = 0.5 },
                        new Ingredient{ Name = "Baking Soda", Instrument = MeasuringType.Teaspoon, Amount = 0.75 },
                        new Ingredient{ Name = "Packed Brown Sugar", Instrument = MeasuringType.Cup, Amount = 0.5 },
                        new Ingredient{ Name = "Salt", Instrument = MeasuringType.Teaspoon, Amount = 0.25 },
                        new Ingredient{ Name = "Egg", Instrument = MeasuringType.Item, Amount = 1 },
                    },
                    Instructions = "Chill dough. Roll into balls the size of walnuts. Place on lightly greased cookie sheet." +
                    " Flatten with fork dipped in flour, making criss-cross pattern. Bake at 375 degrees for 10-12 minutes."
                },
                new Recipe
                {
                    Id = new Id<Recipe>(2),
                    Name = "Applesauce Cookies",
                    Description = "A simple recipe for making Peanut Butter Cookies, 15 minute prep-time.",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient{ Name = "Softened Margarine or Butter", Instrument = MeasuringType.Cup, Amount = 0.75 },
                        new Ingredient{ Name = "Sifted Flour", Instrument = MeasuringType.Cup, Amount = 2.25 },
                        new Ingredient{ Name = "Brown Sugar", Instrument = MeasuringType.Cup, Amount = 1.0 },
                        new Ingredient{ Name = "Baking Soda", Instrument = MeasuringType.Teaspoon, Amount = 0.5 },
                        new Ingredient{ Name = "Egg", Instrument = MeasuringType.Item, Amount = 1 },
                        new Ingredient{ Name = "Cinnamon", Instrument = MeasuringType.Teaspoon, Amount = 0.75 },
                        new Ingredient{ Name = "Applesauce", Instrument = MeasuringType.Cup, Amount = 0.5 },
                        new Ingredient{ Name = "Salt", Instrument = MeasuringType.Teaspoon, Amount = 0.5 },
                        new Ingredient{ Name = "Cloves", Instrument = MeasuringType.Teaspoon, Amount = 0.25 },
                        new Ingredient{ Name = "Seedless Rasins", Instrument = MeasuringType.Cup, Amount = 1.0 },
                        new Ingredient{ Name = "Chopped Nuts", Instrument = MeasuringType.Cup, Amount = 0.5 },
                    },
                    Instructions = "Mix together thouroughly shortening, brown sugar, and egg. Stir in applesauce." +
                    " Sift together flour, soda, salt, spices, and then add to wet ingredients. Mix in rasins and nuts." +
                    " Drop by spoon onto greased cooky sheet. Cook at 375 degrees for 10 to 12 minutes."
                }
            };
        }

        public async Task<IResult<IEnumerable<Recipe>>> GetSavedRecipes()
        {
            try
            {
                //This is hackish but since there is no database to back the appliction its done via a local static refence.
                if (_mockedDataSource == null)
                    _mockedDataSource = InitRecipeList();

                return new Result<IEnumerable<Recipe>> { Value = _mockedDataSource };
            }
            catch (Exception e)
            {
                return new Result<IEnumerable<Recipe>>
                {
                    Errors = new List<IError> { new Error { ErrorMessage = e.Message, Suggestions = _dataConnectionUnavailable } }
                };
            }
        }

        public async Task<IError> SaveRecipe(Recipe recipe)
        {
            try
            {
                //Check to see if the save is an update to existing.
                if (recipe.Id != null)
                    _mockedDataSource.Remove(_mockedDataSource.Where(x => x.Id == recipe.Id).FirstOrDefault());

                //If the recipe is new we need to auto increment the Id, notmally this is handled by the data store.
                if (recipe.Id == null)
                {
                    var currentMaxIdRecipe = _mockedDataSource.OrderByDescending(x => x.Id).FirstOrDefault();
                    recipe.Id = new Id<Recipe>(currentMaxIdRecipe == null ? 1 : currentMaxIdRecipe.Id.Value + 1);
                }

                //Add the new recipe and return out no error.
                _mockedDataSource.Add(recipe);
                return null;
            }
            catch (Exception e)
            {
                return new Error { ErrorMessage = e.Message, Suggestions = _dataConnectionUnavailable };
            }
        }
    }
}
