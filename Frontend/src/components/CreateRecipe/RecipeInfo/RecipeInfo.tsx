import TextArea from "../../TextField/TextArea";
import TextInput from "../../TextField/TextInput";
import styles from "./RecipeInfo.module.scss";

const RecipeInfo = () => {
  return (
    <div className={styles.container}>
      <TextInput
        setText={(text: string) => console.log(text)}
        placeHolder="Some text"
      ></TextInput>
      <TextArea
        setText={(text: string) => console.log(text)}
        placeHolder="Area"
      ></TextArea>
    </div>
  );
};

export default RecipeInfo;
