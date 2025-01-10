import styles from "./ImageInput.module.scss";
import loadIcon from "../../assets/load.svg";

type ImageInputProps = {
  image?: string;
  setImage: (image: string) => void;
};

const ImageInput = ({ image, setImage }: ImageInputProps) => {
  return (
    <div className={styles.container}>
      <label className={styles.label} htmlFor="image-input">
        {image !== null && image !== "" ? (
          <img className={styles.image} src={image}></img>
        ) : (
          <div className={styles.frame}>
            <img className={styles.loadIcon} src={loadIcon}></img>
            <p className={styles.title}>Загрузите фото готового блюда</p>
          </div>
        )}
      </label>
      <input
        id="image-input"
        className={styles.input}
        type="file"
        accept=".png, .jpeg, .jpg"
        onChange={(e) => {
          if (e.target.files === null) {
            return;
          }

          const file = e.target.files[0];

          const reader = new FileReader();
          reader.onload = (e) => {
            try {
              setImage(e.target?.result as string);
            } catch (error) {
              console.error(error);
            }
          };

          reader.readAsDataURL(file);
        }}
      ></input>
    </div>
  );
};

export default ImageInput;
