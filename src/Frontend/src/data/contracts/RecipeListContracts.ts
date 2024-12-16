export type GetRecipeListRequest = {
  groupNum: number;
  count: number;
  orderType: string;
  isAsc: boolean;
  userId: number;
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
};
