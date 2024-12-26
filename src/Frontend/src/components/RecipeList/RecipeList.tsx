import { useEffect, useState } from "react";
import { RecipeType } from "../../data/entities/Recipe";
import RecipePreview from "./RecipePreview/RecipePreview";
import styles from "./RecipeList.module.scss";
import Button from "../Buttons/Button";

type RecipeListProps = {
  getRecipes: (groupNum: number, count: number) => Promise<RecipeType[]>;
};

const Count = 4;

const RecipeList = ({ getRecipes }: RecipeListProps) => {
  const [data, setData] = useState<RecipeType[]>([]);

  useEffect(() => {
    const getRecipeList = async () => {
      setData(await getRecipes(1, Count));
    };

    getRecipeList();
  }, [getRecipes]);

  const loadMore = () => {
    const getRecipeList = async () => {
      if (data.length % Count !== 0) {
        return;
      }

      const recipes = [...data];
      const nextGroupNum = Math.floor(data.length / Count) + 1;

      const newData = await getRecipes(nextGroupNum, Count);
      newData.forEach((recipe) => {
        if (!recipes.some((r) => r.id === recipe.id)) {
          recipes.push(recipe);
        }
      });

      setData(recipes);
    };

    getRecipeList();
  };

  return (
    <div className={styles.container}>
      <ul className={styles.list}>
        {data.map((r) => (
          <li key={"" + r.id} className={styles.elt}>
            <RecipePreview data={r}></RecipePreview>
          </li>
        ))}
      </ul>
      <div className={styles.btn}>
        <Button onClick={loadMore}>Загрузить ещё</Button>
      </div>
    </div>
  );
};

export default RecipeList;
