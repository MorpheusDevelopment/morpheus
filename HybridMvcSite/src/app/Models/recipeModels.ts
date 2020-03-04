
export class RecipeModel {
  id: number;
  name: string;
  description: string;
  ingredients: IngredientModel[];
  instructions: string;
}

export class IngredientModel {
  amount: number;
  instrument: MeasuringTypeModel;
  name: string;
}

export enum MeasuringTypeModel {
  Dash = 1,
  Teaspoon,
  Tablespoon,
  Cup,
  Gallon,
  ToTaste,
  Item
}
