import {
  GetRecipeListRequest,
  GetRecipeListResponse,
} from "../data/contracts/RecipeListContracts";
import ApiRequest from "./ApiRequsts";

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
      count: 4,
      isAsc: isAsc,
      orderType: orderType,
      searchName: searchName,
    },
    "POST"
  );

  return response;
};

export { GetRecipeList };
