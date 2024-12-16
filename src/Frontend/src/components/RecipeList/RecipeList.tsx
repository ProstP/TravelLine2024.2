import { useEffect, useState } from "react";
import { RecipeType } from "../../data/entities/Recipe";
import { GetRecipeList } from "../../services/RecipeListServices";
import { useNavigate } from "react-router-dom";
import RecipePreview from "./RecipePreview/RecipePreview";
import styles from "./RecipeList.module.scss";
import Button from "../Buttons/Button";

type RecipeListProps = {
  isForUser?: boolean;
};

const RecipeList = ({ isForUser }: RecipeListProps) => {
  const navigate = useNavigate();
  const [data, setData] = useState<RecipeType[]>([]);

  useEffect(() => {
    const getRecipes = async () => {
      const response = await GetRecipeList(1);

      if (!response.isSuccess) {
        navigate("/");
      }

      console.log(response.value);

      setData(
        response.value.map((r) => ({
          id: r.id,
          name: r.name,
          description: r.description,
          cookingTime: r.cookingTime,
          personNum: r.personNum,
          tags: r.tags,
          image: r.image,
        }))
      );
    };

    //getRecipes();
    setData([
      {
        id: 0,
        name: "Название",
        description: "Описание",
        cookingTime: 15,
        personNum: 5,
        tags: ["мясо", "обед", "суп"],
        image: "",
      },
    ]);
  }, []);

  const loadMore = async () => {
    const response = await GetRecipeList(2);

    if (!response.isSuccess) {
      navigate("/");
    }

    console.log(response.value);

    const newData = [...data];
    newData.concat(
      response.value.map((r) => ({
        id: r.id,
        name: r.name,
        description: r.description,
        cookingTime: r.cookingTime,
        personNum: r.personNum,
        tags: r.tags,
        image: r.image,
      }))
    );

    setData(newData);
  };

  return (
    <div className={styles.container}>
      <ul className={styles.list}>
        {data.map((r) => (
          <li key={"" + r.id}>
            <RecipePreview data={r}></RecipePreview>
          </li>
        ))}
      </ul>
      <div className={styles.btn}>
        <Button onClick={() => console.log("Load")}>Загрузить ещё</Button>
      </div>
    </div>
  );
};

export default RecipeList;
