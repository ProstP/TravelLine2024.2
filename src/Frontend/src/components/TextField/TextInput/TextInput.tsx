import { useRef } from "react";
import styles from "./TextInput.module.scss";

type TextInputProps = {
  setText: (text: string) => void;
  placeHolder: string;
  disabled?: boolean;
  value?: string;
  isError?: boolean;
};

const TextInput = ({
  setText,
  placeHolder,
  disabled,
  value,
  isError,
}: TextInputProps) => {
  const ref = useRef<HTMLInputElement>(null);

  return (
    <div className={styles.container}>
      <input
        ref={ref}
        disabled={disabled}
        type="text"
        className={`${styles.input} ${isError ? styles.error : ``}`}
        placeholder=""
        onChange={(e) => setText(e.target.value)}
        value={value}
      ></input>
      <label className={styles.help} onClick={() => ref.current?.focus()}>
        {placeHolder}
      </label>
    </div>
  );
};

export default TextInput;
