import styles from "./RecipeListPage.module.scss";
import RecipeList from "../RecipeList/RecipeList";
import SearchRecipeInput from "../SearchRecipeInput/SearchRecipeInput";

const RecipeListPage = () => {
  return (
    <div className={styles.container}>
      <div className={styles.searchfield}>
        <p className={styles.searchtitle}>Поиск рецепта</p>
        <SearchRecipeInput
          onClick={(text) => console.log(text)}
        ></SearchRecipeInput>
      </div>
      <RecipeList></RecipeList>
    </div>
  );
};

export default RecipeListPage;
