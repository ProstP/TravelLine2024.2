import {
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
  >("like/user", data, "POST", true);

  console.log(response.value);

  if (!response.isSuccess) {
    return false;
  }

  return response.value.isSet;
};

export { SetLike, IsUserSetLike };
