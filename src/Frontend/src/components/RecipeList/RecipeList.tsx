import { useEffect, useState } from "react";
import { RecipeType } from "../../data/entities/Recipe";
import { GetRecipeList } from "../../services/RecipeListServices";
import { useNavigate } from "react-router-dom";
import RecipePreview from "./RecipePreview/RecipePreview";

const RecipeList = () => {
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

    getRecipes();
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
    <div>
      <ul>
        {data.map((r) => (
          <li id={"" + r.id}>
            <RecipePreview data={r}></RecipePreview>
          </li>
        ))}
      </ul>
      <button onClick={loadMore}>Загрузить ещё</button>
    </div>
  );
};

export default RecipeList;
