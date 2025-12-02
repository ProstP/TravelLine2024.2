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
      <ul className={styles.list}>
        {data.map((value) => (
          <li key={value.id}>
            <IngredientDetail info={value}></IngredientDetail>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default IngredientsDetail;
