using Objects.Generics;
using System.Collections.Generic;

namespace Objects
{
    //A set of instructions for preparing a particular dish.
    public class Recipe
    {
        public Id<Recipe>? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
    }

    //Any of the foods or substances that are combined to make a particular dish. 
    public class Ingredient
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public MeasuringType Instrument { get; set; }
    }

    public enum MeasuringType
    {
        Dash = 1,
        Teaspoon,
        Tablespoon,
        Cup,
        Gallon,
        ToTaste,
        Item
    }
}
