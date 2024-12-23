import styles from "./UserProfile.module.scss";
import UserInfo from "./UserInfo/UserInfo";
import RecipeList from "../RecipeList/RecipeList";
import { GetRecipeListByUser } from "../../services/RecipeListServices";

const UserProfile = () => {
  const getRecipes = async (groupNum: number, count: number) => {
    const response = await GetRecipeListByUser(groupNum, count);

    if (!response.isSuccess) {
      return [];
    }

    return response.value;
  };

  return (
    <div className={styles.container}>
      <div className={styles.content}>
        <p className={styles.title}>Мой профиль</p>
        <UserInfo></UserInfo>
      </div>
      <div className={styles.recipes}>
        <p className={styles.title}>Мои рецепты</p>
        <RecipeList getRecipes={getRecipes}></RecipeList>
      </div>
    </div>
  );
};

export default UserProfile;
