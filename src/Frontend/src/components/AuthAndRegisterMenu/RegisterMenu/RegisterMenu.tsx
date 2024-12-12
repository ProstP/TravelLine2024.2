import { useState } from "react";
import Button from "../../Buttons/Button";
import PopApMenu from "../../PopApMenu/PopApMenu";
import TextInput from "../../TextField/TextInput/TextInput";
import styles from "./RegisterMenu.module.scss";
import { RegisterUserRequest } from "../../../data/contracts/UserContracts";
import { Register } from "../../../services/UserServices";
import ErrorMessage from "../../ErrorMessage/ErrorMessage";
import { useNavigate } from "react-router-dom";

type RegisterData = RegisterUserRequest & {
  passwordRepeat: string;
};

type FieldErrors = {
  login: boolean;
  name: boolean;
  password: boolean;
  passwordRepeat: boolean;
};

const RegisterMenu = () => {
  const navigate = useNavigate();

  const [data, setData] = useState<RegisterData>({
    name: "",
    login: "",
    password: "",
    passwordRepeat: "",
  });
  const [fieldError, setFieldError] = useState<FieldErrors>({
    login: false,
    name: false,
    password: false,
    passwordRepeat: false,
  });
  const [isError, toggleError] = useState(false);

  const register = async () => {
    if (
      data.login === "" ||
      data.name === "" ||
      data.password.length < 8 ||
      data.passwordRepeat.length < 8
    ) {
      setFieldError({
        name: data.name === "",
        login: data.login === "",
        password: data.password.length < 8,
        passwordRepeat: data.passwordRepeat.length < 8,
      });
      return;
    }

    if (data.password !== data.passwordRepeat) {
      setFieldError({
        name: false,
        login: false,
        password: false,
        passwordRepeat: true,
      });
      return;
    }

    const response = await Register(data);
    if (!response.isSuccess) {
      console.log(response.value);
      toggleError(true);
      return;
    }

    navigate("auth");
  };

  return (
    <PopApMenu exit={() => navigate("/")}>
      <div className={styles.container}>
        {isError ? (
          <ErrorMessage>Ошибка при регистрации пользователя</ErrorMessage>
        ) : null}
        <p className={styles.title}>Регистрация</p>
        <TextInput
          setText={(text: string) => setData({ ...data, name: text })}
          placeHolder="Имя"
          isError={fieldError.name}
        ></TextInput>
        <TextInput
          setText={(text: string) => setData({ ...data, login: text })}
          placeHolder="Логин"
          isError={fieldError.login}
        ></TextInput>
        <div className={styles.doubleElts}>
          <div className={styles.fieldWithHelp}>
            <TextInput
              setText={(text: string) => setData({ ...data, password: text })}
              placeHolder="Пароль"
              isError={fieldError.password}
            ></TextInput>
            <span className={styles.helpText}>Минимум 8 символов</span>
          </div>
          <TextInput
            setText={(text: string) =>
              setData({ ...data, passwordRepeat: text })
            }
            placeHolder="Повторите пароль"
            isError={fieldError.passwordRepeat}
          ></TextInput>
        </div>
        <div className={styles.doubleElts}>
          <Button isFilled={true} onClick={register}>
            Зарегестрироваться
          </Button>
          <Button onClick={() => navigate("/")}>Отмена</Button>
        </div>
        <div>
          <span className={styles.link} onClick={() => navigate("/auth")}>
            У меня ещё нет аккааунта
          </span>
        </div>
      </div>
    </PopApMenu>
  );
};

export default RegisterMenu;
