import styles from "./ErrorMessage.module.scss";

type ErrorMessageProps = {
  children: string;
};

const ErrorMessage = ({ children }: ErrorMessageProps) => {
  return (
    <div className={styles.container}>
      <p className={styles.text}>{children}</p>
    </div>
  );
};

export default ErrorMessage;
