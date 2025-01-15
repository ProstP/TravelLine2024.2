import { useNavigate } from "react-router-dom";
import styles from "./FavouriteList.module.scss";
import { useMaryFoodStore } from "../../hooks/useMaryFoodStore";
import { useEffect } from "react";

const FavouriteList = () => {
  const navigate = useNavigate();

  const username = useMaryFoodStore((store) => store.username);
  useEffect(() => {
    if (username === "") {
      navigate("/");
    }
  }, [username]);

  return <div></div>;
};

export default FavouriteList;
