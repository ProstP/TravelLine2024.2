import { useRef, useState } from "react";
import styles from "./PasswordInput.module.scss";
import hideIcon from "../../../assets/hide.svg";

type PasswordInputProps = {
  disabled?: boolean;
  setText: (text: string) => void;
  placeHolder: string;
  value?: string;
  isError?: boolean;
};

const PasswordInput = ({
  setText,
  placeHolder,
  disabled,
  isError,
  value,
}: PasswordInputProps) => {
  const ref = useRef<HTMLInputElement>(null);
  const [visible, setVisible] = useState(false);

  return (
    <div className={styles.container}>
      <input
        ref={ref}
        disabled={disabled}
        type={visible ? "text" : "password"}
        className={`${styles.input} ${isError ? styles.error : ``}`}
        placeholder=""
        value={value}
        onChange={(e) => setText(e.target.value)}
      ></input>
      <label className={styles.help} onClick={() => ref.current?.focus()}>
        {placeHolder}
      </label>
      <img
        className={styles.hide}
        src={hideIcon}
        onClick={() => setVisible(!visible)}
      ></img>
    </div>
  );
};

export default PasswordInput;
