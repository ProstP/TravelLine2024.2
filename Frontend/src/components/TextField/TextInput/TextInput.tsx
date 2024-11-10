import { useRef } from "react";
import styles from "./TextInput.module.scss";

type TextInputProps = {
  setText: (text: string) => void;
  placeHolder: string;
};

const TextInput = ({ setText, placeHolder }: TextInputProps) => {
  const ref = useRef<HTMLInputElement>(null);

  return (
    <div className={styles.container}>
      <input
        ref={ref}
        type="text"
        className={styles.input}
        placeholder=""
        onChange={(e) => setText(e.target.value)}
      ></input>
      <label className={styles.help} onClick={() => ref.current?.focus()}>
        {placeHolder}
      </label>
    </div>
  );
};

export default TextInput;
