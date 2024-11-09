import styles from "./TextInput.module.scss";

type TextInputProps = {
  setText: (text: string) => void;
  placeHolder: string;
};

const TextInput = ({ setText, placeHolder }: TextInputProps) => {
  return (
    <input
      type="text"
      className={styles.input}
      placeholder={placeHolder}
      onChange={(e) => setText(e.target.value)}
    ></input>
  );
};

export default TextInput;
