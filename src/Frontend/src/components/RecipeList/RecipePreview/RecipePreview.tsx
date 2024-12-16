import { RecipeType } from "../../../data/entities/Recipe";
import image from "../../../temp/Panna-cota.png";
import styles from "./RecipePreview.module.scss";
import clockIcon from "../../../assets/clock.svg";
import personsIcon from "../../../assets/persons.svg";
import { useNavigate } from "react-router-dom";

type RecipePreviewProps = {
  data: RecipeType;
};

const RecipePreview = ({ data }: RecipePreviewProps) => {
  const navigate = useNavigate();

  return (
    <a
      className={styles.container}
      onClick={() => navigate("/recipe/" + data.id)}
    >
      <img className={styles.image} src={image}></img>
      <div className={styles.info}>
        <div className={styles.taglist}>
          {data.tags.map((t, index) => (
            <div className={styles.tagcontainer} key={index}>
              <p className={styles.tag}>{t}</p>
            </div>
          ))}
        </div>
        <p className={styles.title}>{data.name}</p>
        <div className={styles.description}>
          <p className={styles.text}>{data.description}</p>
        </div>
        <div className={styles.bottompanel}>
          <div className={styles.bottomelt}>
            <img className={styles.icon} src={clockIcon}></img>
            <div className={styles.bottomelttext}>
              <p className={styles.bottomelttitle}>Время приготовления:</p>
              <p className={styles.text}>{data.cookingTime} мин</p>
            </div>
          </div>
          <div className={styles.bottomelt}>
            <img className={styles.icon} src={personsIcon}></img>
            <div className={styles.bottomelttext}>
              <p className={styles.bottomelttitle}>Рецепт на:</p>
              <p className={styles.text}>{data.personNum} персон</p>
            </div>
          </div>
        </div>
      </div>
    </a>
  );
};

export default RecipePreview;
