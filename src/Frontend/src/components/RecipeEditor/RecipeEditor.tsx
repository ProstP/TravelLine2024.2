import { useState } from "react";
import styles from "./RecipeEditor.module.scss";
import RecipeSteps from "./RecipeSteps/RecipeSteps";
import Ingredients from "./Inrgedients/Ingredients";
import {
  IngredientType,
  RecipeData,
  RecipeType,
  StepType,
} from "../../data/entities/Recipe";
import RecipeInfo from "./RecipeInfo/RecipeInfo";
import Button from "../Buttons/Button";

type RecipeEditorProps = {
  title: string;
  btnStr: string;
  onClick: (data: RecipeData) => void;
  data?: RecipeData;
  toExit?: () => void;
};

const RecipeEditor = ({
  title,
  btnStr,
  onClick,
  data,
  toExit,
}: RecipeEditorProps) => {
  const [recipe, setRecipe] = useState<RecipeType>(
    data === undefined
      ? {
          id: 0,
          name: "",
          description: "",
          cookingTime: 0,
          personNum: 0,
          tags: [],
          image: "",
          likeCount: 0,
          favouriteCount: 0,
        }
      : data!.info
  );
  const [steps, setSteps] = useState<StepType[]>(
    data === undefined
      ? [
          {
            id: 0,
            text: "",
          },
        ]
      : data!.steps
  );
  const [ingredients, setIngredients] = useState<IngredientType[]>(
    data === undefined
      ? [
          {
            id: 0,
            header: "",
            text: "",
          },
        ]
      : data!.ingredients
  );

  return (
    <div className={styles.container}>
      <div className={styles.topPanel}>
        <p className={styles.title}>{title}</p>
        <div
          className={`${styles.btn} ${toExit === undefined ? `` : styles.doubleBtn}`}
        >
          {toExit === undefined ? null : (
            <Button onClick={toExit}>Отмена</Button>
          )}
          <Button
            isFilled={true}
            onClick={() => {
              const image =
                recipe.image.indexOf("http://") > -1 ? "" : recipe.image;

              onClick({
                info: {
                  id: recipe.id,
                  name: recipe.name,
                  description: recipe.description,
                  cookingTime: recipe.cookingTime,
                  personNum: recipe.personNum,
                  tags: recipe.tags,
                  likeCount: recipe.likeCount,
                  favouriteCount: recipe.favouriteCount,
                  image: image,
                },
                steps: steps,
                ingredients: ingredients,
              });
            }}
          >
            {btnStr}
          </Button>
        </div>
      </div>
      <RecipeInfo data={recipe} setData={setRecipe}></RecipeInfo>
      <div className={styles.anotherInfo}>
        <div className={styles.ingredients}>
          <Ingredients
            ingredients={ingredients}
            setIngredients={setIngredients}
          ></Ingredients>
        </div>
        <div className={styles.steps}>
          <RecipeSteps steps={steps} setSteps={setSteps}></RecipeSteps>
        </div>
      </div>
    </div>
  );
};

export default RecipeEditor;
