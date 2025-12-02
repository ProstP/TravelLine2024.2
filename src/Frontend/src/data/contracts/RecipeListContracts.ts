export type GetRecipeListRequest = {
  groupNum: number;
  count: number;
  orderType?: string;
  searchName?: string;
  isAsc: boolean;
};

export type GetRecipeListResponse = {
  id: number;
  name: string;
  description: string;
  cookingTime: number;
  personNum: number;
  image: string;
  createdDate: string;
  userId: number;
  tags: string[];
  likeCount: number;
  favouriteCount: number;
};

export type GetRecipeListByUserRequest = {
  groupNum: number;
  count: number;
};
