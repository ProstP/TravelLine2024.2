import styles from "./FavouriteBtn.module.scss";
import favoriteIcon from "../../assets/favourite.svg";
import fillFavouriteIcon from "../../assets/favouriteFill.svg";
import { useEffect, useState } from "react";
import {
  GetFavouriteCountByRecipe,
  IsUserSetFavourite,
  SetFavourite,
} from "../../services/FavouriteServices";

type FavouriteBtnProps = {
  count: number;
  recipeId: number;
};

const FavouriteBtn = ({ count, recipeId }: FavouriteBtnProps) => {
  const [isUserSet, toggleUserSet] = useState(false);
  const [value, setValue] = useState(count);

  const getIsUserSet = async () => {
    toggleUserSet(await IsUserSetFavourite({ recipeId: recipeId }));
  };

  const getFavouriteCount = async () => {
    setValue(await GetFavouriteCountByRecipe({ recipeId: recipeId }));
  };

  useEffect(() => {
    getIsUserSet();
  }, []);

  const click = async () => {
    const response = await SetFavourite({ recipeId: recipeId });

    if (response.isSuccess) {
      getFavouriteCount();
      getIsUserSet();
    }
  };

  return (
    <button className={styles.btn} onClick={click}>
      <img
        className={styles.icon}
        src={isUserSet ? fillFavouriteIcon : favoriteIcon}
      ></img>
      <p className={styles.text}>{value}</p>
    </button>
  );
};

export default FavouriteBtn;
