import { useState } from "react";
import styles from "./SearchRecipeInput.module.scss";
import Button from "../Buttons/Button";

type SearchRecipeInputProps = {
  text?: string;
  onClick: (text: string) => void;
};

const SearchRecipeInput = ({
  onClick,
  text: value,
}: SearchRecipeInputProps) => {
  const [text, setText] = useState(value ?? "");

  return (
    <div className={styles.container}>
      <input
        className={styles.input}
        type="text"
        onChange={(e) => setText(e.target.value)}
        value={text}
        placeholder="Название Блюда..."
      ></input>
      <div className={styles.btn}>
        <Button onClick={() => onClick(text)} isFilled={true}>
          Поиск
        </Button>
      </div>
    </div>
  );
};

export default SearchRecipeInput;
