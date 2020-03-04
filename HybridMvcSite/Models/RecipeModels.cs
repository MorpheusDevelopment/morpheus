using System.Collections.Generic;

namespace HybridMvcSite.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IngredientModel> Ingredients { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
    }

    //Any of the foods or substances that are combined to make a particular dish. 
    public class IngredientModel
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public MeasuringTypeModel Instrument { get; set; }
    }

    public enum MeasuringTypeModel
    {
        Dash,
        Teaspoon,
        Tablespoon,
        Cup,
        Gallon,
        ToTaste,
        Item
    }
}
