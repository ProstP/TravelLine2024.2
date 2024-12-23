import styles from "./DropBtn.module.scss";
import arrow from "../../assets/arrow.svg";

type DropBtnProps = {
  options: string[];
  value?: string;
  onChange: (value: string) => void;
};

const DropBtn = ({ options, value, onChange }: DropBtnProps) => {
  return (
    <div className={styles.container}>
      <img className={styles.arrow} src={arrow}></img>
      <select
        className={styles.select}
        onChange={(e) => onChange(e.target.value)}
        value={value}
      >
        {options.map((option) => (
          <option key={option} className={styles.option} value={option}>
            {option}
          </option>
        ))}
      </select>
    </div>
  );
};

export default DropBtn;
