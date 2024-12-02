import { useRef } from "react";
import styles from "./NumberInput.module.scss";

type NumberInputProps = {
  setValue: (value: number) => void;
  placeHolder: string;
  disabled?: boolean;
  value?: number;
  isError?: boolean;
};

const NumberInput = ({
  setValue,
  placeHolder,
  disabled,
  value,
  isError,
}: NumberInputProps) => {
  const ref = useRef<HTMLInputElement>(null);

  return (
    <div className={styles.container}>
      <input
        ref={ref}
        disabled={disabled}
        type="number"
        className={`${styles.input} ${isError ? styles.error : ``}`}
        placeholder=""
        onChange={(e) => setValue(Number(e.target.value))}
        value={value}
      ></input>
      <label className={styles.help} onClick={() => ref.current?.focus()}>
        {placeHolder}
      </label>
    </div>
  );
};

export default NumberInput;
