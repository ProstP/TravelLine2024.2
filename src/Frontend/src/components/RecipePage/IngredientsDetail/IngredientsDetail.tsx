import { IngredientType } from "../../../data/entities/Recipe";
import IngredientDetail from "./IngredientDetail/IngredientDetail";
import styles from "./IngredientsDetail.module.scss";

type IngredientsDetailProps = {
  data: IngredientType[];
};

const IngredientsDetail = ({ data }: IngredientsDetailProps) => {
  return (
    <div className={styles.container}>
      <p className={styles.title}>Ингридиенты</p>
      {data.map((value) => (
        <IngredientDetail info={value}></IngredientDetail>
      ))}
    </div>
  );
};

export default IngredientsDetail;
