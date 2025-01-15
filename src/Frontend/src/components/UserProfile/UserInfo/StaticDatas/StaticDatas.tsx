import styles from "./StaticData.module.scss";
import StaticData from "./StaticData/StaticData";

type StaticDatasProps = {
  recipeCount: number;
  likeCount: number;
  favouriteCount: number;
};

const StaticDatas = ({
  recipeCount,
  likeCount,
  favouriteCount,
}: StaticDatasProps) => {
  return (
    <div className={styles.container}>
      <StaticData
        text="Количество рецептов, созданных вами"
        count={recipeCount}
      ></StaticData>
      <StaticData
        text="Количество рецептов, которые заслужили вашего лайка"
        count={likeCount}
      ></StaticData>
      <StaticData
        text="Количество рецептов, которые попали в вашу коллекцию избранного"
        count={favouriteCount}
      ></StaticData>
    </div>
  );
};

export default StaticDatas;
