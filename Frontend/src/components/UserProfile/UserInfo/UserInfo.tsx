import { useState } from "react";
import styles from "./UserInfo.module.scss";
import editIcon from "../../../assets/edit.svg";
import TextInput from "../../TextField/TextInput/TextInput";
import TextArea from "../../TextField/TextArea/TextArea";
import Button from "../../Buttons/Button";
import PasswordInput from "../../TextField/PasswordInput/PasswordInput";

const UserInfo = () => {
  const [canEdit, toggleCanEdit] = useState(false);

  return (
    <div className={styles.container}>
      <div className={styles.fields}>
        <div className={styles.required}>
          <TextInput
            disabled={!canEdit}
            setText={(name) => console.log(name)}
            placeHolder="Имя"
          ></TextInput>
          <TextInput
            disabled={!canEdit}
            setText={(name) => console.log(name)}
            placeHolder="Логин"
          ></TextInput>
          <PasswordInput
            disabled={!canEdit}
            setText={(name) => console.log(name)}
            placeHolder="Пароль"
          ></PasswordInput>
        </div>
        <div className={styles.about}>
          <TextArea
            disabled={!canEdit}
            setText={(name) => console.log(name)}
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
