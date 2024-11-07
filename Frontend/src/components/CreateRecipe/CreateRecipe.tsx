import RecipeInfo from "./RecipeInfo/RecipeInfo";
import styles from "./CreateRecipe.module.scss";

const CreateRecipe = () => {
  return (
    <div className={styles.container}>
      <RecipeInfo></RecipeInfo>
    </div>
  );
};

export default CreateRecipe;
