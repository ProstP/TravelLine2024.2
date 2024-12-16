import {
  GetRecipeListRequest,
  GetRecipeListResponse,
} from "../data/contracts/RecipeListContracts";
import ApiRequest from "./ApiRequsts";

const GetRecipeList = async (groupNum: number) => {
  const response = await ApiRequest<
    GetRecipeListRequest,
    GetRecipeListResponse[]
  >(
    "recipes",
    { groupNum: groupNum, count: 2, userId: 0, orderType: "", isAsc: false },
    "POST"
  );

  return response;
};

export { GetRecipeList };
