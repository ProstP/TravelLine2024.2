import Button from "../../Buttons/Button";
import PopApMenu from "../../PopApMenu/PopApMenu";
import TextInput from "../../TextField/TextInput/TextInput";
import styles from "./AuthenticationMenu.module.scss";

type AuthenticationMenuProps = {
  exit: () => void;
  toRegister: () => void;
  login: () => void;
};

const AuthenticationMenu = ({
  exit,
  toRegister,
  login,
}: AuthenticationMenuProps) => {
  return (
    <PopApMenu exit={exit}>
      <div className={styles.container}>
        <p className={styles.title}>Войти</p>
        <TextInput
          setText={(text: string) => console.log(text)}
          placeHolder="Логин"
        ></TextInput>
        <TextInput
          setText={(text: string) => console.log(text)}
          placeHolder="Пароль"
        ></TextInput>
        <div className={styles.btns}>
          <Button isFilled={true} onClick={login}>
            Войти
          </Button>
          <Button isFilled={false} onClick={exit}>
            Отмена
          </Button>
        </div>
        <div>
          <span className={styles.link} onClick={toRegister}>
            У меня ещё нет аккааунта
          </span>
        </div>
      </div>
    </PopApMenu>
  );
};

export default AuthenticationMenu;
