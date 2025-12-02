import { RecipeType } from "../../../data/entities/Recipe";
import styles from "./RecipePreview.module.scss";
import clockIcon from "../../../assets/clock.svg";
import personsIcon from "../../../assets/persons.svg";
import { useNavigate } from "react-router-dom";
import LikeBtn from "../../LikeBtn/LikeBtn";
import FavouriteBtn from "../../FavouriteBtn/FavouriteBtn";

type RecipePreviewProps = {
  data: RecipeType;
};

const RecipePreview = ({ data }: RecipePreviewProps) => {
  const navigate = useNavigate();

  return (
    <div className={styles.container}>
      <div className={styles.favouriteBtn}>
        <FavouriteBtn
          count={data.favouriteCount}
          recipeId={data.id}
        ></FavouriteBtn>
      </div>
      <div className={styles.likeBtn}>
        <LikeBtn count={data.likeCount} recipeId={data.id}></LikeBtn>
      </div>
      <a className={styles.link} onClick={() => navigate("/recipe/" + data.id)}>
        <img className={styles.image} src={data.image}></img>
        <div className={styles.info}>
          <div className={styles.taglist}>
            {data.tags.length < 10
              ? data.tags.map((t, index) => (
                  <div className={styles.tagcontainer} key={index}>
                    <p className={styles.tag}>{t}</p>
                  </div>
                ))
              : data.tags.slice(0, 9).map((t, index) => (
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
    </div>
  );
};

export default RecipePreview;
