import styles from "./RecipeInfoDetail.module.scss";
import { RecipeType } from "../../../data/entities/Recipe";
import clockIcon from "../../../assets/clock.svg";
import personsIcon from "../../../assets/persons.svg";
import LikeBtn from "../../LikeBtn/LikeBtn";
import FavouriteBtn from "../../FavouriteBtn/FavouriteBtn";

type RecipeInfoDetailProps = {
  data: RecipeType;
};

const RecipeInfoDetail = ({ data }: RecipeInfoDetailProps) => {
  return (
    <div className={styles.container}>
      <img className={styles.image} src={data.image}></img>
      <div className={styles.fields}>
        <div className={styles.like}>
          <LikeBtn count={data.likeCount} recipeId={data.id}></LikeBtn>
        </div>
        <div className={styles.favourite}>
          <FavouriteBtn
            count={data.favouriteCount}
            recipeId={data.id}
          ></FavouriteBtn>
        </div>
        <div className={styles.topPanel}>
          <div className={styles.tags}>
            {data.tags.length < 10
              ? data.tags.map((value, index) => (
                  <div key={index} className={styles.tag}>
                    {value}
                  </div>
                ))
              : data.tags.slice(0, 9).map((value, index) => (
                  <div key={index} className={styles.tag}>
                    {value}
                  </div>
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
