import styles from "./RecipeListPage.module.scss";
import RecipeList from "../RecipeList/RecipeList";
import SearchRecipeInput from "../SearchRecipeInput/SearchRecipeInput";
import { useNavigate } from "react-router-dom";
import { GetRecipeList } from "../../services/RecipeListServices";

const RecipeListPage = () => {
  const navigate = useNavigate();

  const getRecipes = async (groupNum: number) => {
    const response = await GetRecipeList(groupNum, false);

    if (!response.isSuccess) {
      navigate("/");
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
          onClick={(text) => console.log(text)}
        ></SearchRecipeInput>
      </div>
      <RecipeList getRecipes={getRecipes}></RecipeList>
    </div>
  );
};

export default RecipeListPage;
