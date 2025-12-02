export type SetLikeRequest = {
  recipeId: number;
};

export type IsUserSetLikeRequest = {
  recipeId: number;
};

export type IsUserSetLikeResponse = {
  isSet: boolean;
};

export type GetLikeCountByRecipeRequest = {
  recipeId: number;
};

export type GetLikeCountByRecipeResponse = {
  count: number;
};
