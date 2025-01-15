import styles from "./Ingredients.module.scss";
import Button from "../../Buttons/Button";
import Ingredient from "./Ingredient/Ingredient";
import { IngredientType } from "../../../data/entities/Recipe";

type IngredientsProps = {
  ingredients: IngredientType[];
  setIngredients: (info: IngredientType[]) => void;
};

const Ingredients = ({ ingredients, setIngredients }: IngredientsProps) => {
  const editIngredient = (index: number, value: IngredientType) => {
    const newIngedients = [...ingredients];
    newIngedients[index] = { ...value };

    setIngredients(newIngedients);
  };
  const deleteIngredients = (index: number) => {
    if (ingredients.length == 1) {
      return;
    }

    const newIngedients = [...ingredients];
    newIngedients.splice(index, 1);

    setIngredients(newIngedients);
  };

  return (
    <div className={styles.container}>
      <p className={styles.title}>Ингридиенты</p>
      {ingredients.map((value: IngredientType, index: number) => (
        <Ingredient
          key={value.id}
          info={value}
          setInfo={(info) => editIngredient(index, info)}
          deleteInfo={() => deleteIngredients(index)}
        ></Ingredient>
      ))}
      <div className={styles.btn}>
        <Button
          onClick={() =>
            setIngredients([...ingredients, { id: 0, header: "", text: "" }])
          }
        >
          + Добавить заголовок
        </Button>
      </div>
    </div>
  );
};

export default Ingredients;
