import styles from "./Footer.module.scss";

const Footer = () => {
  return (
    <div className={styles.container}>
      <p className={styles.title}>Mary Food</p>
      <p className={styles.copyright}>© Mary Food 2024</p>
    </div>
  );
};

export default Footer;
