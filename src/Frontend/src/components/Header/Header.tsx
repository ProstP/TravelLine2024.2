import styles from "./Header.module.scss";
import userIcon from "../../assets/user.svg";
import exitIcon from "../../assets/exit.svg";
import { useMaryFoodStore } from "../../hooks/useMaryFoodStore";

type HeaderProps = {
  Logout: () => void;
};

const Header = ({ Logout }: HeaderProps) => {
  const username = useMaryFoodStore((store) => store.username);

  return (
    <div className={styles.container}>
      <div className={styles.titlecontainer}>
        <p className={styles.title}>Mary Food</p>
        <div className={styles.linkcontainer}>
          <a className={styles.link} href="/">
            Главная
          </a>
          <a className={styles.link} href="/recipes">
            Рецепты
          </a>
          <a className={styles.link}>Избранное</a>
        </div>
      </div>
      <div className={styles.usercontainer}>
        {username !== "" ? (
          <>
            <img src={userIcon}></img>
            <a className={styles.username} href="/user-profile">
              Привет, {username}
            </a>
            <div className={styles.verticalline}></div>
            <button
              className={styles.exitbtn}
              onClick={() => {
                Logout();
              }}
            >
              <img src={exitIcon}></img>
            </button>
          </>
        ) : (
          <p className={styles.linktitle}>
            <a className={styles.link} href="/auth">
              Войти
            </a>{" "}
            /{" "}
            <a className={styles.link} href="/register">
              Зарегистрироваться
            </a>
          </p>
        )}
      </div>
    </div>
  );
};

export default Header;
