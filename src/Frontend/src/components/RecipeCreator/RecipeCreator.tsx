import { useNavigate } from "react-router-dom";
import { RecipeData } from "../../data/entities/Recipe";
import { CreateRecipe } from "../../services/RecipeServices";
import RecipeEditor from "../RecipeEditor/RecipeEditor";
import { useMaryFoodStore } from "../../hooks/useMaryFoodStore";
import { useEffect } from "react";

const RecipeCreator = () => {
  const navigate = useNavigate();

  const username = useMaryFoodStore((store) => store.username);

  useEffect(() => {
    if (username === "") {
      navigate("/");
    }
  }, [username]);

  const sendRequest = async (data: RecipeData) => {
    const response = await CreateRecipe({
      name: data.info.name,
      description: data.info.description,
      cookingTime: data.info.cookingTime,
      personNum: data.info.personNum,
      image: data.info.image,
      tags: data.info.tags,
      ingredients: data.ingredients.map((i) => ({
        header: i.header,
        subIngredients: i.text,
      })),
      recipeSteps: data.steps.map((s) => ({ description: s.text })),
    });

    if (response.isSuccess) {
      navigate("/recipes");
    }
  };

  return (
    <RecipeEditor
      title="Добавить новый рецепт"
      btnStr="Опубликовать"
      onClick={(data) => sendRequest(data)}
    />
  );
};

export default RecipeCreator;
