import styles from "./RecipeListPage.module.scss";
import RecipeList from "../RecipeList/RecipeList";
import SearchRecipeInput from "../SearchRecipeInput/SearchRecipeInput";
import { GetRecipeList } from "../../services/RecipeListServices";
import DropBtn from "../DropBtn/DropBtn";
import { useState } from "react";

type SortType = "Date" | "Like" | "Favourite";

const RecipeListPage = () => {
  const [searchStr, setSearchStr] = useState("");
  const [sortType, setSort] = useState<SortType>("Date");
  const [isAsc, togleAsc] = useState<boolean>(false);

  const getRecipes = async (
    groupNum: number,
    isAsc: boolean,
    sortType: SortType,
    searchStr: string
  ) => {
    const response = await GetRecipeList(groupNum, isAsc, sortType, searchStr);

    if (!response.isSuccess) {
      return [];
    }

    return response.value.map((r) => ({
      id: r.id,
      name: r.name,
      description: r.description,
      cookingTime: r.cookingTime,
      personNum: r.personNum,
      tags: r.tags,
      image: r.image,
    }));
  };

  return (
    <div className={styles.container}>
      <div className={styles.searchfield}>
        <p className={styles.searchtitle}>Поиск рецепта</p>
        <SearchRecipeInput
          text={searchStr}
          onClick={(text) => setSearchStr(text)}
        ></SearchRecipeInput>
      </div>
      <div className={styles.sortbtns}>
        <p className={styles.sorttitle}>Сортировать:</p>
        <div className={styles.sortbtn}>
          <DropBtn
            options={["Дате публикации", "Лайкам", "Избранным"]}
            value={
              sortType === "Date"
                ? "Дате публикации"
                : sortType === "Favourite"
                  ? "Избранным"
                  : "Лайкам"
            }
            onChange={(value) =>
              value === "Дате публикации"
                ? setSort("Date")
                : value === "Лайкам"
                  ? setSort("Like")
                  : setSort("Favourite")
            }
          ></DropBtn>
        </div>
        <p className={styles.sorttitle}>по:</p>
        <div className={styles.sortbtn}>
          <DropBtn
            options={["убыванию", "возрастанию"]}
            onChange={(value) => togleAsc(value === "возрастанию")}
            value={isAsc ? "возрастанию" : "убыванию"}
          ></DropBtn>
        </div>
      </div>
      <RecipeList
        sortType={sortType}
        isAsc={isAsc}
        searchStr={searchStr}
        getRecipes={getRecipes}
      ></RecipeList>
    </div>
  );
};

export default RecipeListPage;
