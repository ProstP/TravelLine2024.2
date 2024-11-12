import { useRef } from "react";
import styles from "./TextArea.module.scss";

type TextAreaProps = {
  setText: (text: string) => void;
  placeHolder?: string;
  disabled?: boolean;
  value?: string;
};

const TextArea = ({ setText, placeHolder, disabled, value }: TextAreaProps) => {
  const ref = useRef<HTMLTextAreaElement>(null);

  return (
    <div className={styles.container}>
      <textarea
        ref={ref}
        disabled={disabled}
        className={styles.area}
        onChange={(e) => setText(e.target.value)}
        placeholder=""
        value={value}
      ></textarea>
      <label className={styles.help} onClick={() => ref.current?.focus()}>
        {placeHolder}
      </label>
    </div>
  );
};

export default TextArea;