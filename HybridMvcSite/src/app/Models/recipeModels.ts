import { Id } from '../Models/Generics/id';

export class RecipeModel {
  id: Id<RecipeModel>;
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

export interface DropdownViewModel {
  value: string;
  viewValue: string;
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
