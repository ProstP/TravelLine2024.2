import { useEffect, useState } from "react";
import styles from "./UserInfo.module.scss";
import editIcon from "../../../assets/edit.svg";
import TextInput from "../../TextField/TextInput/TextInput";
import TextArea from "../../TextField/TextArea/TextArea";
import Button from "../../Buttons/Button";
import PasswordInput from "../../TextField/PasswordInput/PasswordInput";
import { Profile } from "../../../services/UserServices";

type UserInfoProps = {
  exit: () => void;
};

type UserData = {
  name: string;
  login: string;
  password: string;
  about: string;
};

const UserInfo = ({ exit }: UserInfoProps) => {
  const [user, setUser] = useState<UserData>({
    name: "",
    login: "",
    password: "",
    about: "",
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

  return (
    <div className={styles.container}>
      <div className={styles.fields}>
        <div className={styles.required}>
          <TextInput
            disabled={!canEdit}
            setText={(text) => setUser({ ...user, name: text })}
            value={user.name}
            placeHolder="Имя"
          ></TextInput>
          <TextInput
            disabled={!canEdit}
            setText={(text) => setUser({ ...user, login: text })}
            value={user.login}
            placeHolder="Логин"
          ></TextInput>
          <PasswordInput
            disabled={!canEdit}
            setText={(text) => setUser({ ...user, password: text })}
            value={user.password}
            placeHolder="Пароль"
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
          <Button onClick={() => console.log("Save")} isFilled={true}>
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
