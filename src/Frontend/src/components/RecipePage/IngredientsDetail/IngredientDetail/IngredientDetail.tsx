import { IngredientType } from "../../../../data/entities/Recipe";
import styles from "./IngredientDetail.module.scss";

type IngredientDetailProps = {
  info: IngredientType;
};

const IngredientDetail = ({ info }: IngredientDetailProps) => {
  return (
    <div className={styles.container}>
      <p className={styles.header}>{info.header}</p>
      <span className={styles.text}>{info.text}</span>
    </div>
  );
};

export default IngredientDetail;
