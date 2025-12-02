export type SetFavouriteRequest = {
  recipeId: number;
};

export type IsUserSetFavouriteRequest = {
  recipeId: number;
};

export type IsUserSetFavouriteResponse = {
  isSet: boolean;
};

export type GetFavouriteCountByRecipeRequest = {
  recipeId: number;
};

export type GetFavouriteCountByRecipeResponse = {
  count: number;
};
