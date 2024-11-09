import { useState } from "react";
import styles from "./UserInfo.module.scss";
import editIcon from "../../../assets/edit.svg";
import TextInput from "../../TextField/TextInput/TextInput";
import TextArea from "../../TextField/TextArea/TextArea";

const UserInfo = () => {
  const [canEdit, toggleCanEdit] = useState(false);

  return (
    <div className={styles.container}>
      <div className={styles.required}>
        <TextInput
          setText={(name) => console.log(name)}
          placeHolder="Имя"
        ></TextInput>
        <TextInput
          setText={(name) => console.log(name)}
          placeHolder="Логин"
        ></TextInput>
        <TextInput
          setText={(name) => console.log(name)}
          placeHolder="Пароль"
        ></TextInput>
      </div>
      <div className={styles.about}>
        <TextArea
          setText={(name) => console.log(name)}
          placeHolder="Напишите немного о себе"
        ></TextArea>
      </div>
      <img
        className={styles.edit}
        src={editIcon}
        onClick={() => toggleCanEdit(true)}
      ></img>
    </div>
  );
};

export default UserInfo;
