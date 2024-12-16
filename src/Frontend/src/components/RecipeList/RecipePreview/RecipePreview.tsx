import { RecipeType } from "../../../data/entities/Recipe";
import image from "../../../temp/Panna-cota.png";

type RecipePreviewProps = {
  data: RecipeType;
};

const RecipePreview = ({ data }: RecipePreviewProps) => {
  return (
    <div>
      <img src={image}></img>
      <div>
        <p>{data.name}</p>
        <p>{data.description}</p>
        {data.tags.map((t) => (
          <p>{t}</p>
        ))}
        <p>{data.cookingTime}</p>
        <p>{data.personNum}</p>
      </div>
    </div>
  );
};

export default RecipePreview;
