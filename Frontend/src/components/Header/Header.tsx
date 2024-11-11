import { useMaryFoodStore } from "../../hooks/useMaryFoodStore.ts";
import styles from "./Header.module.scss";
import userIcon from "../../assets/user.svg";
import exitIcon from "../../assets/exit.svg";

type HeaderProps = {
  OpenRegAndAuthMenu: () => void;
  OpenUserProfile: () => void;
  Logout: () => void;
};

const Header = ({
  OpenRegAndAuthMenu,
  OpenUserProfile,
  Logout,
}: HeaderProps) => {
  const selected = useMaryFoodStore((store) => store.selectedPage);
  const username = useMaryFoodStore((store) => store.username);
  const setName = useMaryFoodStore((store) => store.setUsername);

  return (
    <div className={styles.container}>
      <div className={styles.titlecontainer}>
        <p className={styles.title}>Mary Food</p>
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
        {username !== "" ? (
          <>
            <img src={userIcon}></img>
            <a className={styles.username} onClick={OpenUserProfile}>
              Привет, {username}
            </a>
            <div className={styles.verticalline}></div>
            <button
              className={styles.exitbtn}
              onClick={() => {
                Logout();
                setName("");
              }}
            >
              <img src={exitIcon}></img>
            </button>
          </>
        ) : (
          <>
            <a className={styles.link} onClick={OpenRegAndAuthMenu}>
              Войти / Зарегестрироваться
            </a>
          </>
        )}
      </div>
    </div>
  );
};

export default Header;
