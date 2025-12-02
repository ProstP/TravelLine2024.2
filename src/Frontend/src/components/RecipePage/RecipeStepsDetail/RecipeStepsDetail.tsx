import { StepType } from "../../../data/entities/Recipe";
import RecipeStepDetail from "./RecipeStepDetial/RecipeStepDetail";
import styles from "./RecipeStepsDetail.module.scss";

type RecipeStepsDetailProps = {
  steps: StepType[];
};

const RecipeStepsDetail = ({ steps }: RecipeStepsDetailProps) => {
  return (
    <div className={styles.container}>
      <ul className={styles.list}>
        {steps.map((value, index) => (
          <li key={value.id}>
            <RecipeStepDetail
              stepNum={index + 1}
              info={value}
            ></RecipeStepDetail>
          </li>
        ))}
      </ul>
      <p className={styles.wishtitle}>Приятного аппетита!</p>
    </div>
  );
};

export default RecipeStepsDetail;
