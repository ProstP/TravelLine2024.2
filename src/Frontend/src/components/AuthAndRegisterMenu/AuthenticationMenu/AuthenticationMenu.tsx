import { useState } from "react";
import Button from "../../Buttons/Button";
import PopApMenu from "../../PopApMenu/PopApMenu";
import TextInput from "../../TextField/TextInput/TextInput";
import styles from "./AuthenticationMenu.module.scss";
import { LoginUserRequest } from "../../../data/contracts/UserContracts";
import ErrorMessage from "../../ErrorMessage/ErrorMessage";
import { useMaryFoodStore } from "../../../core/hooks/useMaryFoodStore";
import { Authenticate } from "../../../core/services/UserServices";

type AuthenticationMenuProps = {
  exit: () => void;
  toRegister: () => void;
};

type FieldErrors = {
  login: boolean;
  password: boolean;
};

const AuthenticationMenu = ({ exit, toRegister }: AuthenticationMenuProps) => {
  const setName = useMaryFoodStore((state) => state.setUsername);
  const [data, setData] = useState<LoginUserRequest>({
    login: "",
    password: "",
  });
  const [fieldError, setFieldError] = useState<FieldErrors>({
    login: false,
    password: false,
  });
  const [isError, toggleError] = useState(false);

  const Login = async () => {
    if (data.login === "" || data.password === "") {
      setFieldError({
        login: data.login === "",
        password: data.password === "",
      });

      return;
    }

    const response = await Authenticate(data);
    if (!response.isSuccess) {
      toggleError(true);
      return;
    }

    setName(response.value.username);
    exit();
  };

  return (
    <PopApMenu exit={exit}>
      <div className={styles.container}>
        {isError ? (
          <ErrorMessage>Неправильный логин или пароль</ErrorMessage>
        ) : null}
        <p className={styles.title}>Войти</p>
        <TextInput
          setText={(text: string) => setData({ ...data, login: text })}
          placeHolder="Логин"
          isError={fieldError.login}
        ></TextInput>
        <TextInput
          setText={(text: string) => setData({ ...data, password: text })}
          placeHolder="Пароль"
          isError={fieldError.password}
        ></TextInput>
        <div className={styles.btns}>
          <Button isFilled={true} onClick={Login}>
            Войти
          </Button>
          <Button onClick={exit}>Отмена</Button>
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
