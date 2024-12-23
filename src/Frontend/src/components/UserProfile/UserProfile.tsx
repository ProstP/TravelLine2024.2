import styles from "./UserProfile.module.scss";
import UserInfo from "./UserInfo/UserInfo";
import RecipeList from "../RecipeList/RecipeList";
import { GetRecipeListByUser } from "../../services/RecipeListServices";
import { useNavigate } from "react-router-dom";
import { useMaryFoodStore } from "../../hooks/useMaryFoodStore";
import { useEffect } from "react";

const UserProfile = () => {
  const navigate = useNavigate();

  const username = useMaryFoodStore((store) => store.username);

  useEffect(() => {
    if (username === "") {
      navigate("/");
    }
  }, [username]);

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
