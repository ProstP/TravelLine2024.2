import { useEffect, useState } from "react";
import styles from "./UserInfo.module.scss";
import editIcon from "../../../assets/edit.svg";
import TextInput from "../../TextField/TextInput/TextInput";
import TextArea from "../../TextField/TextArea/TextArea";
import Button from "../../Buttons/Button";
import PasswordInput from "../../TextField/PasswordInput/PasswordInput";
import { Profile, Update } from "../../../services/UserServices";
import ErrorMessage from "../../ErrorMessage/ErrorMessage";
import { useMaryFoodStore } from "../../../hooks/useMaryFoodStore";

type UserInfoProps = {
  exit: () => void;
};

type UserData = {
  name: string;
  login: string;
  password: string;
  about: string;
};

type FieldError = {
  name: boolean;
  login: boolean;
  password: boolean;
};

const UserInfo = ({ exit }: UserInfoProps) => {
  const setName = useMaryFoodStore((state) => state.setUsername);
  const [user, setUser] = useState<UserData>({
    name: "",
    login: "",
    password: "",
    about: "",
  });
  const [fieldError, setFeildError] = useState<FieldError>({
    name: false,
    login: false,
    password: false,
  });

  useEffect(() => {
    const getUserInfo = async () => {
      const result = await Profile();

      if (!result.isSuccess) {
        exit();
        return;
      }

      setUser({
        name: result.value.name,
        login: result.value.login,
        password: "",
        about: result.value.about,
      });
    };

    getUserInfo();
  }, []);

  const [canEdit, toggleCanEdit] = useState(false);
  const [isError, toggleError] = useState(false);

  const UpdateInfo = async () => {
    if (
      user.name === "" ||
      user.login === "" ||
      (user.password.length != 0 && user.password.length < 8)
    ) {
      setFeildError({
        name: user.name === "",
        login: user.login === "",
        password: user.password.length != 0 && user.password.length < 8,
      });

      return;
    }

    const response = await Update(user);
    if (!response.isSuccess) {
      console.log(response.value);
      toggleError(true);
    }

    setName(user.name);
    toggleError(false);
    toggleCanEdit(false);
  };

  return (
    <div className={styles.container}>
      {isError ? (
        <ErrorMessage>Ошибка при обновления данных</ErrorMessage>
      ) : null}
      <div className={styles.fields}>
        <div className={styles.required}>
          <TextInput
            disabled={!canEdit}
            setText={(text) => setUser({ ...user, name: text })}
            value={user.name}
            placeHolder="Имя"
            isError={fieldError.name}
          ></TextInput>
          <TextInput
            disabled={!canEdit}
            setText={(text) => setUser({ ...user, login: text })}
            value={user.login}
            placeHolder="Логин"
            isError={fieldError.login}
          ></TextInput>
          <PasswordInput
            disabled={!canEdit}
            setText={(text) => setUser({ ...user, password: text })}
            value={user.password}
            placeHolder="Пароль"
            isError={fieldError.password}
          ></PasswordInput>
        </div>
        <div className={styles.about}>
          <TextArea
            disabled={!canEdit}
            setText={(text) => setUser({ ...user, about: text })}
            value={user.about}
            placeHolder="Напишите немного о себе"
          ></TextArea>
        </div>
      </div>
      {canEdit ? (
        <div className={styles.btns}>
          <Button onClick={UpdateInfo} isFilled={true}>
            Сохранить
          </Button>
          <Button onClick={() => toggleCanEdit(false)}>Отмена</Button>
        </div>
      ) : null}
      <img
        className={styles.edit}
        src={editIcon}
        onClick={() => toggleCanEdit(true)}
      ></img>
    </div>
  );
};

export default UserInfo;
