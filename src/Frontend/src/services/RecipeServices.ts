import {
  CreateRecipeRequest,
  GetRecipeResponse,
} from "../data/contracts/RecipeContracts";
import ApiRequest from "./ApiRequsts";

const CreateRecipe = async (data: CreateRecipeRequest) => {
  const response = await ApiRequest<CreateRecipeRequest>(
    "recipe/create",
    data,
    "POST",
    true
  );

  return response;
};

const GetRecipe = (id: number) => {
  const response = ApiRequest<null, GetRecipeResponse>(
    "recipe/" + id,
    null,
    "GET"
  );

  return response;
};

export { CreateRecipe, GetRecipe };
