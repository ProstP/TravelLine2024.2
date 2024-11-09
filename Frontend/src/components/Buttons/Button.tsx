import styles from "./Button.module.scss";

type ButtonProps = {
  isFilled: boolean;
  children: string;
  onClick: () => void;
};

const Button = ({ isFilled, children, onClick }: ButtonProps) => {
  return (
    <button
      className={`${styles.btn} ${isFilled ? styles.filledBtn : styles.notFilledBtn}`}
      onClick={onClick}
    >
      {children}
    </button>
  );
};

export default Button;
