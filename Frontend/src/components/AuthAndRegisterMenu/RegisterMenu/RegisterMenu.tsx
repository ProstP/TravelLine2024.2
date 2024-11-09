import Button from "../../Buttons/Button";
import PopApMenu from "../../PopApMenu/PopApMenu";
import TextInput from "../../TextField/TextInput";
import styles from "./RegisterMenu.module.scss";

type RegisterMenuProps = {
  exit: () => void;
  toLogin: () => void;
  register: () => void;
};

const RegisterMenu = ({ exit, toLogin, register }: RegisterMenuProps) => {
  return (
    <PopApMenu exit={exit}>
      <div className={styles.container}>
        <p className={styles.title}>Регистрация</p>
        <TextInput
          setText={(text: string) => console.log(text)}
          placeHolder="Имя"
        ></TextInput>
        <TextInput
          setText={(text: string) => console.log(text)}
          placeHolder="Логин"
        ></TextInput>
        <div className={styles.doubleElts}>
          <div className={styles.fieldWithHelp}>
            <TextInput
              setText={(text: string) => console.log(text)}
              placeHolder="Пароль"
            ></TextInput>
            <span className={styles.helpText}>Минимум 8 символов</span>
          </div>
          <TextInput
            setText={(text: string) => console.log(text)}
            placeHolder="Повторите пароль"
          ></TextInput>
        </div>
        <div className={styles.doubleElts}>
          <Button isFilled={true} onClick={register}>
            Зарегестрироваться
          </Button>
          <Button isFilled={false} onClick={exit}>
            Отмена
          </Button>
        </div>
        <div>
          <span className={styles.link} onClick={toLogin}>
            У меня ещё нет аккааунта
          </span>
        </div>
      </div>
    </PopApMenu>
  );
};

export default RegisterMenu;
