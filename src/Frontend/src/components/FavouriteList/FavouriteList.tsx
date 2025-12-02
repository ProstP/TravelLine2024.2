import { useNavigate } from "react-router-dom";
import { useMaryFoodStore } from "../../hooks/useMaryFoodStore";
import { useEffect } from "react";
import RecipeList from "../RecipeList/RecipeList";
import { GetRecipeListByFavourite } from "../../services/RecipeListServices";
import styles from "./FavouriteList.module.scss";

const FavouriteList = () => {
  const navigate = useNavigate();

  const username = useMaryFoodStore((store) => store.username);
  useEffect(() => {
    if (username === "") {
      navigate("/");
    }
  }, [username]);

  const getRecipes = async (groupNum: number, count: number) => {
    const response = await GetRecipeListByFavourite(groupNum, count);

    if (!response.isSuccess) {
      return [];
    }

    return response.value;
  };

  return (
    <div className={styles.container}>
      <div className={styles.list}>
        <RecipeList getRecipes={getRecipes}></RecipeList>;
      </div>
    </div>
  );
};

export default FavouriteList;
