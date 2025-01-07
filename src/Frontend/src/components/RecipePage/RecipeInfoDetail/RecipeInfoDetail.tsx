import styles from "./RecipeInfoDetail.module.scss";
import { RecipeType } from "../../../data/entities/Recipe";
import clockIcon from "../../../assets/clock.svg";
import personsIcon from "../../../assets/persons.svg";

type RecipeInfoDetailProps = {
  data: RecipeType;
};

const RecipeInfoDetail = ({ data }: RecipeInfoDetailProps) => {
  return (
    <div className={styles.container}>
      <img className={styles.image} src={data.image}></img>
      <div className={styles.fields}>
        <div className={styles.topPanel}>
          <div className={styles.tags}>
            {data.tags.map((value) => (
              <div className={styles.tag}>{value}</div>
            ))}
          </div>
        </div>
        <p className={styles.title}>{data.description}</p>
        <div className={styles.doublefield}>
          <div className={styles.smallfield}>
            <img className={styles.icon} src={clockIcon}></img>
            <div className={styles.smallfielddata}>
              <p className={styles.dataname}>Время приготовления:</p>
              <p className={styles.title}>{data.cookingTime} мин</p>
            </div>
          </div>
          <div className={styles.smallfield}>
            <img className={styles.icon} src={personsIcon}></img>
            <div className={styles.smallfielddata}>
              <p className={styles.dataname}>Рецепт на</p>
              <p className={styles.title}>{data.personNum} персон</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default RecipeInfoDetail;
