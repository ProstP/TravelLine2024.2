import styles from "./DropBtn.module.scss";
import arrow from "../../svg/arrow.svg";

type DropBtnProps = {
  name: string;
  options: string[];
  onChange: (value: string) => void;
};

const DropBtn = ({ name, options, onChange }: DropBtnProps) => {
  return (
    <div className={styles.container}>
      <img className={styles.arrow} src={arrow}></img>
      <select
        className={styles.select}
        onChange={(e) => onChange(e.target.value)}
        value={name}
      >
        <option key={name} className={styles.option} disabled value={name}>
          {name}
        </option>
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
