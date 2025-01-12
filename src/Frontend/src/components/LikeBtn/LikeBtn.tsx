import { useEffect, useState } from "react";
import styles from "./LikeBtn.module.scss";
import { IsUserSetLike, SetLike } from "../../services/LikeServices";
import likeIcon from "../../assets/like.svg";
import fillLikeIcon from "../../assets/likeFill.svg";

type LikeBtnProps = {
  count: number;
  recipeId: number;
};

const LikeBtn = ({ count, recipeId }: LikeBtnProps) => {
  const [isUserSet, toggleUserSet] = useState(false);
  const [value, setValue] = useState(count);

  const getIsUserSet = async () => {
    toggleUserSet(await IsUserSetLike({ recipeId: recipeId }));
  };

  useEffect(() => {
    getIsUserSet();
  }, []);

  const click = async () => {
    const response = await SetLike({ recipeId: recipeId });

    if (response.isSuccess) {
      const newValue = isUserSet ? value - 1 : value + 1;

      setValue(newValue);
      getIsUserSet();
    }
  };

  return (
    <button className={styles.btn} onClick={click}>
      <img
        className={styles.icon}
        src={isUserSet ? fillLikeIcon : likeIcon}
      ></img>
      <p className={styles.text}>{value}</p>
    </button>
  );
};

export default LikeBtn;
