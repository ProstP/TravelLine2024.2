import styles from "./RecipeStep.module.scss";
import crossIcon from "../../../../assets/cross.svg";
import TextArea from "../../../TextField/TextArea/TextArea";
import { StepType } from "../../../../data/entities/Recipe";

type RecipeStepProps = {
  stepNum: number;
  info: StepType;
  setInfo: (info: StepType) => void;
  deleteStep: () => void;
};

const RecipeStep = ({
  stepNum,
  info,
  setInfo,
  deleteStep,
}: RecipeStepProps) => {
  return (
    <div className={styles.container}>
      <img className={styles.cross} src={crossIcon} onClick={deleteStep}></img>
      <p className={styles.title}>Шаг {stepNum}</p>
      <div className={styles.field}>
        <TextArea
          placeHolder="Описание шага"
          value={info.text}
          setText={(text) => setInfo({ ...info, text: text })}
        ></TextArea>
      </div>
    </div>
  );
};

export default RecipeStep;
