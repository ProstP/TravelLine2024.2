import {
  GetLikeCountByRecipeRequest,
  GetLikeCountByRecipeResponse,
  IsUserSetLikeRequest,
  IsUserSetLikeResponse,
  SetLikeRequest,
} from "../data/contracts/LikeContracts";
import ApiRequest from "./ApiRequsts";

const SetLike = async (data: SetLikeRequest) => {
  const response = await ApiRequest<SetLikeRequest>("like", data, "POST", true);

  return response;
};

const IsUserSetLike = async (data: IsUserSetLikeRequest) => {
  if (localStorage.getItem("username") === null) {
    return false;
  }

  const response = await ApiRequest<
    IsUserSetLikeRequest,
    IsUserSetLikeResponse
  >("like/is-user", data, "POST", true);

  if (!response.isSuccess) {
    return false;
  }

  return response.value.isSet;
};

const GetLikeCountByRecipe = async (data: GetLikeCountByRecipeRequest) => {
  const response = await ApiRequest<
    GetLikeCountByRecipeRequest,
    GetLikeCountByRecipeResponse
  >("like/recipe", data, "POST");

  if (!response.isSuccess) {
    return 0;
  }

  return response.value.count;
};

export { SetLike, IsUserSetLike, GetLikeCountByRecipe };
