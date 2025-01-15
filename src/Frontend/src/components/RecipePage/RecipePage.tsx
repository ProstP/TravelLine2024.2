import { RecipeData } from "../../data/entities/Recipe";
import RecipeInfoDetail from "./RecipeInfoDetail/RecipeInfoDetail";
import styles from "./RecipePage.module.scss";
import basketIcon from "../../assets/basket.svg";
import pencilIcon from "../../assets/pencil-white.svg";
import Button from "../Buttons/Button";
import RecipeStepsDetail from "./RecipeStepsDetail/RecipeStepsDetail";
import IngredientsDetail from "./IngredientsDetail/IngredientsDetail";
import { useEffect, useState } from "react";
import RecipeEditor from "../RecipeEditor/RecipeEditor";
import { useNavigate, useParams } from "react-router-dom";
import {
  DeleteRecipe,
  GetRecipe,
  UpdateRecipe,
} from "../../services/RecipeServices";
import ErrorMessage from "../ErrorMessage/ErrorMessage";

type RecipePageState = "view" | "edit";

const RecipePage = () => {
  const [error, setError] = useState("");
  const idStr = useParams().id;
  const navigate = useNavigate();

  const [data, setData] = useState<RecipeData | undefined>(undefined);

  const [state, setState] = useState<RecipePageState>("view");

  const getRecipe = async () => {
    if (idStr === undefined) {
      navigate("/");
    }

    const response = await GetRecipe(Number(idStr));

    if (!response.isSuccess) {
      navigate("/create-recipe");
    }

    setData({
      info: {
        id: response.value.id,
        name: response.value.name,
        description: response.value.description,
        cookingTime: response.value.cookingTime,
        personNum: response.value.personNum,
        tags: response.value.tags,
        image: response.value.image,
        likeCount: response.value.likeCount,
        favouriteCount: response.value.favouriteCount,
      },
      ingredients: response.value.ingredients.map((i) => ({
        id: i.id,
        header: i.header,
        text: i.subIngredients,
      })),
      steps: response.value.recipeSteps.map((s) => ({
        id: s.id,
        text: s.description,
      })),
    });
  };

  useEffect(() => {
    getRecipe();
  }, []);

  const updateRecipe = async (data: RecipeData) => {
    const response = await UpdateRecipe({
      id: data.info.id,
      name: data.info.name,
      description: data.info.description,
      cookingTime: data.info.cookingTime,
      personNum: data.info.personNum,
      image:
        data.info.image === ""
          ? ""
          : data.info.image.slice(
              data.info.image.indexOf(",") + 1,
              data.info.image.length
            ),
      tags: data.info.tags,
      ingredients: data.ingredients.map((i) => ({
        id: i.id,
        header: i.header,
        subIngredients: i.text,
      })),
      recipeSteps: data.steps.map((s) => ({ id: s.id, description: s.text })),
    });

    if (response.isSuccess) {
      getRecipe();
    } else {
      setError("Ошибка при обновлении данных");
    }

    setState("view");
  };

  const deleteRecipe = async (id: number) => {
    const response = await DeleteRecipe(id);

    if (response.isSuccess) {
      navigate("/recipes");
    }
  };

  return (
    <>
      {data === undefined ? (
        <div style={{ color: "gray" }}>Is Loading</div>
      ) : (
        <>
          {state === "view" ? (
            <div className={styles.container}>
              {error === "" ? null : <ErrorMessage>{error}</ErrorMessage>}
              <div className={styles.topPanel}>
                <p className={styles.title}>{data.info.name}</p>
                <div className={styles.btns}>
                  <button
                    className={styles.deleteBtn}
                    onClick={() => deleteRecipe(data.info.id)}
                  >
                    <img className={styles.smallicon} src={basketIcon}></img>
                  </button>
                  <Button isFilled={true} onClick={() => setState("edit")}>
                    <img
                      className={`${styles.smallicon} ${styles.pencilicon}`}
                      src={pencilIcon}
                    ></img>
                    <span className={styles.smalltitle}>Редактировать</span>
                  </Button>
                </div>
              </div>
              <RecipeInfoDetail data={data.info}></RecipeInfoDetail>
              <div className={styles.anotherInfo}>
                <div className={styles.ingredients}>
                  <IngredientsDetail
                    data={data.ingredients}
                  ></IngredientsDetail>
                </div>
                <div className={styles.steps}>
                  <RecipeStepsDetail steps={data.steps}></RecipeStepsDetail>
                </div>
              </div>
            </div>
          ) : (
            <RecipeEditor
              title="Редактировать рецепт"
              btnStr="Сохранить"
              onClick={(data) => {
                updateRecipe(data);
              }}
              data={{ ...data }}
              toExit={() => setState("view")}
            ></RecipeEditor>
          )}
        </>
      )}
    </>
  );
};

export default RecipePage;
