import styles from "./TextArea.module.scss";

type TextAreaProps = {
  setText: (text: string) => void;
  placeHolder: string;
};

const TextArea = ({ setText, placeHolder }: TextAreaProps) => {
  return (
    <textarea
      className={styles.area}
      onChange={(e) => setText(e.target.value)}
      placeholder={placeHolder}
    ></textarea>
  );
};

export default TextArea;
