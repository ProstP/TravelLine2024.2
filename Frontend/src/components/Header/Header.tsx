import { useMaryFoodStore } from "../../hooks/useMaryFoodStore.ts";
import styles from "./Header.module.scss";
import userIcon from "../../svg/user.svg";
import exitIcon from "../../svg/exit.svg";

const Header = () => {
  const selected = useMaryFoodStore((store) => store.selectedPage);

  return (
    <div className={styles.container}>
      <div className={styles.titlecontainer}>
        <a href="/" className={styles.title}>Mary Food</a>
        <div className={styles.linkcontainer}>
          <a
            className={
              selected === "main"
                ? `${styles.link} ${styles.bold}`
                : styles.link
            }
          >
            Главная
          </a>
          <a
            className={
              selected === "recipe"
                ? `${styles.link} ${styles.bold}`
                : styles.link
            }
          >
            Рецепты
          </a>
          <a
            className={
              selected === "favourite"
                ? `${styles.link} ${styles.bold}`
                : styles.link
            }
          >
            Избранное
          </a>
        </div>
      </div>
      <div className={styles.usercontainer}>
        <img src={userIcon}></img>
        <p className={styles.username}>Привет, user</p>
        <div className={styles.verticalline}></div>
        <button className={styles.exitbtn}>
          <img src={exitIcon}></img>
        </button>
      </div>
    </div>
  );
};

export default Header;
