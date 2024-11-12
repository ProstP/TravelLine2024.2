import { useState } from "react";
import Button from "../../Buttons/Button";
import PopApMenu from "../../PopApMenu/PopApMenu";
import TextInput from "../../TextField/TextInput/TextInput";
import styles from "./AuthenticationMenu.module.scss";
import { LoginUserRequest } from "../../../data/contracts/UserContracts";
import { Authenticate } from "../../../services/UserServices";
import { useMaryFoodStore } from "../../../hooks/useMaryFoodStore";

type AuthenticationMenuProps = {
  exit: () => void;
  toRegister: () => void;
};

const AuthenticationMenu = ({ exit, toRegister }: AuthenticationMenuProps) => {
  const setName = useMaryFoodStore((state) => state.setUsername);
  const [data, setData] = useState<LoginUserRequest>({
    login: "",
    password: "",
  });

  const Login = async () => {
    const response = await Authenticate(data);
    if (!response.isSuccess) {
      console.error("Error");
      return;
    }

    setName(response.value.username);
    exit();
  };

  return (
    <PopApMenu exit={exit}>
      <div className={styles.container}>
        <p className={styles.title}>Войти</p>
        <TextInput
          setText={(text: string) => setData({ ...data, login: text })}
          placeHolder="Логин"
        ></TextInput>
        <TextInput
          setText={(text: string) => setData({ ...data, password: text })}
          placeHolder="Пароль"
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
