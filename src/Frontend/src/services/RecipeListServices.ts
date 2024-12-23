import {
  GetRecipeListByUserRequest,
  GetRecipeListRequest,
  GetRecipeListResponse,
} from "../data/contracts/RecipeListContracts";
import ApiRequest from "./ApiRequsts";

const GetRecipeList = async (
  groupNum: number,
  count: number,
  isAsc: boolean,
  orderType?: string,
  searchName?: string
) => {
  const response = await ApiRequest<
    GetRecipeListRequest,
    GetRecipeListResponse[]
  >(
    "recipes",
    {
      groupNum: groupNum,
      count: count,
      isAsc: isAsc,
      orderType: orderType,
      searchName: searchName,
    },
    "POST"
  );

  return response;
};

const GetRecipeListByUser = async (groupNum: number, count: number) => {
  const response = await ApiRequest<
    GetRecipeListByUserRequest,
    GetRecipeListResponse[]
  >(
    "recipes/by-user",
    {
      groupNum: groupNum,
      count: count,
    },
    "POST",
    true
  );

  return response;
};

export { GetRecipeList, GetRecipeListByUser };
