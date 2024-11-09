import styles from "./UserProfile.module.scss";
import leftArrowIcon from "../../assets/left-arow.svg";
import UserInfo from "./UserInfo/UserInfo";

type UserProfileProps = {
  exit: () => void;
};

const UserProfile = ({ exit }: UserProfileProps) => {
  return (
    <div className={styles.container}>
      <div className={styles.content}>
        <a className={styles.back} onClick={exit}>
          <img src={leftArrowIcon}></img>
          Назад
        </a>
        <p className={styles.title}>Мой профиль</p>
        <UserInfo></UserInfo>
      </div>
    </div>
  );
};

export default UserProfile;
