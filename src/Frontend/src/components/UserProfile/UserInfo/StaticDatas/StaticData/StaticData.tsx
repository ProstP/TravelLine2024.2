import styles from "./StaticData.module.scss";

type StaticDataProps = {
  text: string;
  count: number;
};

const StaticData = ({ text, count }: StaticDataProps) => {
  return (
    <div className={styles.container}>
      <p className={styles.text}>{text}</p>
      <p className={styles.count}>{count}</p>
    </div>
  );
};

export default StaticData;
