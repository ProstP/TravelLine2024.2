export type RecipeType = {
  id: number;
  name: string;
  description: string;
  cookingTime: number;
  personNum: number;
  tags: string[];
  image: string;
  likeCount: number;
  favouriteCount: number;
};

export type IngredientType = {
  id: number;
  header: string;
  text: string;
};

export type StepType = {
  id: number;
  text: string;
};

export type RecipeData = {
  info: RecipeType;
  steps: StepType[];
  ingredients: IngredientType[];
};
