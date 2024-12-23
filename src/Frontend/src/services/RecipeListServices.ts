import {
  GetRecipeListByUserRequest,
  GetRecipeListRequest,
  GetRecipeListResponse,
} from "../data/contracts/RecipeListContracts";
import ApiRequest from "./ApiRequsts";

const Count = 4;

const GetRecipeList = async (
  groupNum: number,
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
      count: Count,
      isAsc: isAsc,
      orderType: orderType,
      searchName: searchName,
    },
    "POST"
  );

  return response;
};

const GetRecipeListByUser = async (groupNum: number) => {
  const response = await ApiRequest<
    GetRecipeListByUserRequest,
    GetRecipeListResponse[]
  >(
    "recipes/by-user",
    {
      groupNum: groupNum,
      count: Count,
    },
    "POST",
    true
  );

  return response;
};

export { GetRecipeList, GetRecipeListByUser };
