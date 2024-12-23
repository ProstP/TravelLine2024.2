import { useEffect, useRef, useState } from "react";
import { RecipeType } from "../../data/entities/Recipe";
import RecipePreview from "./RecipePreview/RecipePreview";
import styles from "./RecipeList.module.scss";
import Button from "../Buttons/Button";

type RecipeListProps = {
  getRecipes: (groupNum: number) => Promise<RecipeType[]>;
};

const RecipeList = ({ getRecipes }: RecipeListProps) => {
  const [data, setData] = useState<RecipeType[]>([]);
  const nextGroupNum = useRef(2);

  useEffect(() => {
    const getRecipeList = async () => {
      setData(await getRecipes(1));
    };

    getRecipeList();
  }, [getRecipes]);

  const loadMore = () => {
    const getRecipeList = async () => {
      const newData = data.concat(await getRecipes(nextGroupNum.current));

      nextGroupNum.current++;
      setData(newData);
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
