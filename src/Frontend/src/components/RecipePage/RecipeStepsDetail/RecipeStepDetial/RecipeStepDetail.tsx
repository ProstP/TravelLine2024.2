import { StepType } from "../../../../data/entities/Recipe";
import styles from "./RecipeStepDetail.module.scss";

type RecipeStepDetailProps = {
  stepNum: number;
  info: StepType;
};

const RecipeStepDetail = ({ stepNum, info }: RecipeStepDetailProps) => {
  return (
    <div className={styles.container}>
      <p className={styles.title}>Шаг {stepNum}</p>
      <p className={styles.text}>{info.text}</p>
    </div>
  );
};

export default RecipeStepDetail;
