import styles from "./Main.module.scss";
import foodImg from "../../assets/food.jpg";

const Main = () => {
  return (
    <div className={styles.container}>
      <div className={styles.info}>
        <div className={styles.texts}>
          <p className={styles.title}>Mary Food</p>
          <p className={styles.helloText}>
            Добро пожаловать на наш сайт. Здесь вы можете создавать рецепты,
            смотреть рецепты других пользователей, оценивать их и добавлять к
            себе на в избранное.
          </p>
        </div>
        <div className={styles.imageBlock}>
          <div className={styles.imageGradient}></div>
          <img className={styles.image} src={foodImg}></img>
        </div>
      </div>
    </div>
  );
};

export default Main;
