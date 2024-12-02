import { RecipeData } from "../../data/entities/Recipe";
import RecipeInfoDetail from "./RecipeInfoDetail/RecipeInfoDetail";
import styles from "./RecipePage.module.scss";
import basketIcon from "../../assets/basket.svg";
import pencilIcon from "../../assets/pencil-white.svg";
import Button from "../Buttons/Button";
import RecipeStepsDetail from "./RecipeStepsDetail/RecipeStepsDetail";
import IngredientsDetail from "./IngredientsDetail/IngredientsDetail";
import { useState } from "react";
import RecipeEditor from "../RecipeEditor/RecipeEditor";
import image from "../../temp/Panna-cota.png";

type RecipePageState = "view" | "edit";

const RecipePage = () => {
  const [data, setData] = useState<RecipeData>({
    info: {
      name: "Клубничная Панна-Котта",
      description:
        "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах, украсив взбитыми сливками, свежими ягодами и мятой.",
      tags: ["десерты", "клубника", "сливки"],
      cookingTime: 35,
      personNum: 5,
      image: image,
    },
    steps: [
      {
        text: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!).",
      },
      {
        text: "Добавим в сливки набухший в молоке желатин. Перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.",
      },
    ],
    ingredients: [
      {
        header: "Для панна котты",
        text: "Сливки-20-30% - 500мл.Молоко - 100мл. Желатин - 2ч.л. Сахар - 3ст.л. Ванильный сахар - 2 ч.л.",
      },
      {
        header: "Для клубничного желе",
        text: "Сливки-20-30% - 500мл.Молоко - 100мл. Желатин - 2ч.л. Сахар - 3ст.л. Ванильный сахар - 2 ч.л.",
      },
    ],
  });

  const [state, setState] = useState<RecipePageState>("view");

  return (
    <>
      {state === "view" ? (
        <div className={styles.container}>
          <div className={styles.topPanel}>
            <p className={styles.title}>{data.info.name}</p>
            <div className={styles.btns}>
              <button
                className={styles.deleteBtn}
                onClick={() => console.log("Delete")}
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
              <IngredientsDetail data={data.ingredients}></IngredientsDetail>
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
            setData(data);
            setState("view");
          }}
          data={{ ...data }}
        ></RecipeEditor>
      )}
    </>
  );
};

export default RecipePage;
