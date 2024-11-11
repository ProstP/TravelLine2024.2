import { useState } from "react";
import Button from "../../Buttons/Button";
import PopApMenu from "../../PopApMenu/PopApMenu";
import TextInput from "../../TextField/TextInput/TextInput";
import styles from "./RegisterMenu.module.scss";
import { RegisterUserRequest } from "../../../data/contracts/UserContracts";
import { Register } from "../../../services/UserServices";

type RegisterMenuProps = {
  exit: () => void;
  toLogin: () => void;
};

type RegisterData = RegisterUserRequest & {
  passwordRepeat: string;
};

const RegisterMenu = ({ exit, toLogin }: RegisterMenuProps) => {
  const [data, setData] = useState<RegisterData>({
    name: "",
    login: "",
    password: "",
    passwordRepeat: "",
  });

  const register = async () => {
    if (data.password !== data.passwordRepeat) {
      return;
    }

    const response = await Register(data);
    if (!response.isSuccess) {
      console.error("Error");
      return;
    }

    toLogin();
  };

  return (
    <PopApMenu exit={exit}>
      <div className={styles.container}>
        <p className={styles.title}>Регистрация</p>
        <TextInput
          setText={(text: string) => setData({ ...data, name: text })}
          placeHolder="Имя"
        ></TextInput>
        <TextInput
          setText={(text: string) => setData({ ...data, login: text })}
          placeHolder="Логин"
        ></TextInput>
        <div className={styles.doubleElts}>
          <div className={styles.fieldWithHelp}>
            <TextInput
              setText={(text: string) => setData({ ...data, password: text })}
              placeHolder="Пароль"
            ></TextInput>
            <span className={styles.helpText}>Минимум 8 символов</span>
          </div>
          <TextInput
            setText={(text: string) =>
              setData({ ...data, passwordRepeat: text })
            }
            placeHolder="Повторите пароль"
          ></TextInput>
        </div>
        <div className={styles.doubleElts}>
          <Button isFilled={true} onClick={register}>
            Зарегестрироваться
          </Button>
          <Button onClick={exit}>Отмена</Button>
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
