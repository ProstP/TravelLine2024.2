import {
  GetFavouriteCountByRecipeRequest,
  GetFavouriteCountByRecipeResponse,
  IsUserSetFavouriteRequest,
  IsUserSetFavouriteResponse,
  SetFavouriteRequest,
} from "../data/contracts/FavouriteContracts";
import ApiRequest from "./ApiRequsts";

const SetFavourite = async (data: SetFavouriteRequest) => {
  const response = await ApiRequest<SetFavouriteRequest>(
    "favourite",
    data,
    "POST",
    true
  );

  return response;
};

const IsUserSetFavourite = async (data: IsUserSetFavouriteRequest) => {
  if (localStorage.getItem("username") === null) {
    return false;
  }

  const response = await ApiRequest<
    IsUserSetFavouriteRequest,
    IsUserSetFavouriteResponse
  >("favourite/is-user", data, "POST", true);

  if (!response.isSuccess) {
    return false;
  }

  return response.value.isSet;
};

const GetFavouriteCountByRecipe = async (
  data: GetFavouriteCountByRecipeRequest
) => {
  const response = await ApiRequest<
    GetFavouriteCountByRecipeRequest,
    GetFavouriteCountByRecipeResponse
  >("favourite/recipe", data, "POST");

  if (!response.isSuccess) {
    return 0;
  }

  return response.value.count;
};

export { SetFavourite, IsUserSetFavourite, GetFavouriteCountByRecipe };
