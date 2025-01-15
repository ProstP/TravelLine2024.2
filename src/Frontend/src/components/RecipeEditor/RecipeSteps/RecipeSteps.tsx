import { StepType } from "../../../data/entities/Recipe";
import Button from "../../Buttons/Button";
import RecipeStep from "./RecipeStep/RecipeStep";
import styles from "./RecipeSteps.module.scss";

type RecipeStepsProps = {
  steps: StepType[];
  setSteps: (steps: StepType[]) => void;
};

const RecipeSteps = ({ steps, setSteps }: RecipeStepsProps) => {
  const editStep = (index: number, step: StepType) => {
    const newSteps = [...steps];
    newSteps[index] = { ...step };

    setSteps(newSteps);
  };

  const deleteStep = (index: number) => {
    if (steps.length == 1) {
      return;
    }

    const newSteps = [...steps];
    newSteps.splice(index, 1);

    setSteps(newSteps);
  };

  return (
    <div className={styles.container}>
      {steps.map((value: StepType, index: number) => (
        <RecipeStep
          key={value.id}
          info={value}
          stepNum={index + 1}
          setInfo={(step: StepType) => editStep(index, step)}
          deleteStep={() => deleteStep(index)}
        ></RecipeStep>
      ))}
      <div className={styles.btn}>
        <Button
          onClick={() => setSteps([...steps, { id: 0, text: "" }])}
          isFilled={false}
        >
          + Добавить шаг
        </Button>
      </div>
    </div>
  );
};

export default RecipeSteps;
