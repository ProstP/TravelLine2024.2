import { useRef } from "react";
import styles from "./TextArea.module.scss";

type TextAreaProps = {
  setText: (text: string) => void;
  placeHolder: string;
};

const TextArea = ({ setText, placeHolder }: TextAreaProps) => {
  const ref = useRef<HTMLTextAreaElement>(null);

  return (
    <div className={styles.container}>
      <textarea
        ref={ref}
        className={styles.area}
        onChange={(e) => setText(e.target.value)}
        placeholder=""
      ></textarea>
      <label className={styles.help} onClick={() => ref.current?.focus()}>
        {placeHolder}
      </label>
    </div>
  );
};

export default TextArea;
