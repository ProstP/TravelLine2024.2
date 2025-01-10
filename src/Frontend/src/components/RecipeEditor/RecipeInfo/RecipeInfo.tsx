import styles from "./RecipeInfo.module.scss";
import TextArea from "../../TextField/TextArea/TextArea";
import TextInput from "../../TextField/TextInput/TextInput";
import ImageInput from "../../ImageInput/ImageInput";
import NumberInput from "../../TextField/NumberInput/NumberInput";
import { RecipeType } from "../../../data/entities/Recipe";

type RecipeInfoProps = {
  data: RecipeType;
  setData: (data: RecipeType) => void;
};

const RecipeInfo = ({ data, setData }: RecipeInfoProps) => {
  return (
    <div className={styles.container}>
      <div className={styles.image}>
        <ImageInput
          image={data.image !== null && data.image !== "" ? data.image : ""}
          setImage={(path) => setData({ ...data, image: path })}
        ></ImageInput>
      </div>
      <div className={styles.fields}>
        <div className={styles.field}>
          <TextInput
            setText={(text: string) => setData({ ...data, name: text })}
            placeHolder="Название рецепта"
            value={data.name}
          ></TextInput>
        </div>
        <div className={styles.bigfield}>
          <TextArea
            setText={(text: string) => setData({ ...data, description: text })}
            placeHolder="Краткое описание рецепта (150 символов)"
            value={data.description}
          ></TextArea>
        </div>
        <div className={styles.field}>
          <TextInput
            setText={(text: string) =>
              setData({ ...data, tags: text.split(/[\s,;:]+/) })
            }
            placeHolder="Добавить тэги"
            value={data.tags.join(" ")}
          ></TextInput>
        </div>
        <div className={styles.doublefield}>
          <div className={styles.smallfield}>
            <div className={styles.smallBtn}>
              <NumberInput
                placeHolder="Время готовки"
                setValue={(value: number) =>
                  setData({ ...data, cookingTime: value })
                }
                value={data.cookingTime}
              ></NumberInput>
            </div>
            <p className={styles.title}>Минут</p>
          </div>
          <div className={styles.smallfield}>
            <div className={styles.smallBtn}>
              <NumberInput
                placeHolder="Порций в блюде"
                setValue={(value: number) =>
                  setData({ ...data, personNum: value })
                }
                value={data.personNum}
              ></NumberInput>
            </div>
            <p className={styles.title}>Персон</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default RecipeInfo;
