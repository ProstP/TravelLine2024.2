import { useNavigate } from "react-router-dom";
import { RecipeData } from "../../data/entities/Recipe";
import { CreateRecipe } from "../../services/RecipeServices";
import RecipeEditor from "../RecipeEditor/RecipeEditor";

const RecipeCreator = () => {
  const navigate = useNavigate();

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
      navigate("/");
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
