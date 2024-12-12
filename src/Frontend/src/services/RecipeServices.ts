import {
  CreateRecipeRequest,
  GetRecipeResponse,
  UpdateRecipeRequest,
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

const UpdateRecipe = (data: UpdateRecipeRequest) => {
  const response = ApiRequest<UpdateRecipeRequest>("recipe", data, "PUT", true);

  return response;
};

const DeleteRecipe = (id: number) => {
  const response = ApiRequest<null>("recipe/" + id, null, "DELETE", true);

  return response;
};

export { CreateRecipe, GetRecipe, UpdateRecipe, DeleteRecipe };
