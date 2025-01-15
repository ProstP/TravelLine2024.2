import TextArea from "../../../TextField/TextArea/TextArea";
import TextInput from "../../../TextField/TextInput/TextInput";
import styles from "./Ingredient.module.scss";
import crossIcon from "../../../../assets/cross.svg";
import { IngredientType } from "../../../../data/entities/Recipe";

type IngredientProps = {
  info: IngredientType;
  setInfo: (info: IngredientType) => void;
  deleteInfo: () => void;
};

const Ingredient = ({ info, setInfo, deleteInfo }: IngredientProps) => {
  return (
    <div className={styles.container}>
      <img className={styles.cross} src={crossIcon} onClick={deleteInfo}></img>
      <div className={styles.content}>
        <div className={styles.wrapper}>
          <TextInput
            value={info.header}
            placeHolder="Заголовок для ингридиентов"
            setText={(text) => setInfo({ ...info, header: text })}
          ></TextInput>
        </div>
        <div className={`${styles.wrapper} ${styles.text}`}>
          <TextArea
            value={info.text}
            placeHolder="Список подуктов для категории"
            setText={(text) => setInfo({ ...info, text: text })}
          ></TextArea>
        </div>
      </div>
    </div>
  );
};

export default Ingredient;
