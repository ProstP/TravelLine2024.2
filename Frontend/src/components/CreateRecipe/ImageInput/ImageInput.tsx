import styles from "./ImageInput.module.scss";
import loadIcon from "../../../svg/load.svg";

const ImageInput = () => {
  return (
    <div className={styles.container}>
      <label className={styles.frame} htmlFor="image-input">
        <img className={styles.image} src={loadIcon}></img>
        <p className={styles.title}>Загрузите фото готового блюда</p>
      </label>
      <input
        id="image-input"
        className={styles.input}
        type="file"
        accept=".png, .jpeg, .jpg"
      ></input>
    </div>
  );
};

export default ImageInput;
