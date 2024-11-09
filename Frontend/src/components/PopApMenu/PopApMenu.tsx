import { ReactNode } from "react";
import styles from "./PopApMenu.module.scss";
import cross from "../../svg/cross.svg";

type PopApMenuProps = {
  exit: () => void;
  children: ReactNode;
};

const PopApMenu = ({ children, exit }: PopApMenuProps) => {
  return (
    <div className={styles.background}>
      <div className={styles.menu}>
        <img className={styles.cross} src={cross} onClick={exit}></img>
        {children}
      </div>
    </div>
  );
};

export default PopApMenu;
