import styles from "./RecipeListPage.module.scss";
import RecipeList from "../RecipeList/RecipeList";

const RecipeListPage = () => {
  return (
    <div className={styles.container}>
      <RecipeList></RecipeList>
    </div>
  );
};

export default RecipeListPage;
