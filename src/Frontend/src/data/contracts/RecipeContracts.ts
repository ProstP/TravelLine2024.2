export type CreateIngredientsRequest = {
  header: string;
  subIngredients: string;
};

export type CreateRecipeStepRequest = {
  description: string;
};

export type CreateRecipeRequest = {
  name: string;
  description: string;
  cookingTime: number;
  personNum: number;
  image: string;
  ingredients: CreateIngredientsRequest[];
  recipeSteps: CreateRecipeStepRequest[];
  tags: string[];
};

export type GetIngredientResponse = {
  id: number;
  header: string;
  subIngredients: string;
};

export type GetRecipeStepResponse = {
  id: number;
  description: string;
};

export type GetRecipeResponse = {
  id: number;
  name: string;
  description: string;
  cookingTime: number;
  personNum: number;
  image: string;
  createdData: string;
  ingredients: GetIngredientResponse[];
  recipeSteps: GetRecipeStepResponse[];
  tags: string[];
};
