import Button from "../../Buttons/Button";
import styles from "./EnterToAccount.module.scss";

type EnterToAccountProps = {
  toLogin: () => void;
  toRegister: () => void;
};

const EnterToAccount = ({ toLogin, toRegister }: EnterToAccountProps) => (
  <>
    <p className={styles.title}>Войдите в профиль</p>
    <p className={styles.text}>
      Добавлять рецепты могут только зарегистрированные пользователи.
    </p>
    <div className={styles.btns}>
      <Button isFilled={true} onClick={toLogin}>
        Войти
      </Button>
      <Button isFilled={false} onClick={toRegister}>
        Регистрация
      </Button>
    </div>
  </>
);

export default EnterToAccount;
