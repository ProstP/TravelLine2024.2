export type RecipeType = {
  name: string;
  description: string;
  cookingTime: number;
  personNum: number;
  tags: string[];
  image: string;
};

export type IngredientType = {
  header: string;
  text: string;
};

export type StepType = {
  text: string;
};

export type RecipeData = {
  info: RecipeType;
  steps: StepType[];
  ingredients: IngredientType[];
};
