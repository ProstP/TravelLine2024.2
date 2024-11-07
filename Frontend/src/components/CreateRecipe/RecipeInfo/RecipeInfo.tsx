import DropBtn from "../../DropBtn/DropBtn";
import TextArea from "../../TextField/TextArea";
import TextInput from "../../TextField/TextInput";
import ImageInput from "../ImageInput/ImageInput";
import styles from "./RecipeInfo.module.scss";

const RecipeInfo = () => {
  return (
    <div className={styles.container}>
      <div className={styles.image}>
        <ImageInput></ImageInput>
      </div>
      <div className={styles.fields}>
        <div className={styles.field}>
          <TextInput
            setText={(text: string) => console.log(text)}
            placeHolder="Название рецепта"
          ></TextInput>
        </div>
        <div className={styles.bigfield}>
          <TextArea
            setText={(text: string) => console.log(text)}
            placeHolder="Краткое описание рецепта (150 символов)"
          ></TextArea>
        </div>
        <div className={styles.field}>
          <TextInput
            setText={(text: string) => console.log(text)}
            placeHolder="Добавить тэги"
          ></TextInput>
        </div>
        <div className={styles.doublefield}>
          <div className={styles.smallfield}>
            <div className={styles.dropbtn}>
              <DropBtn
                name="Время готовки"
                options={["1", "10", "300"]}
                onChange={(value: string) => console.log(value)}
              ></DropBtn>
            </div>
            <p className={styles.title}>Минут</p>
          </div>
          <div className={styles.smallfield}>
            <div className={styles.dropbtn}>
              <DropBtn
                name="Порций в блюде"
                options={["1", "2", "4", "8"]}
                onChange={(value: string) => console.log(value)}
              ></DropBtn>
            </div>
            <p className={styles.title}>Персон</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default RecipeInfo;
