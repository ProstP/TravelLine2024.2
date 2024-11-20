import { create } from "zustand";

type SeelectedPageType = "main" | "recipe" | "favourite";

type StoreData = {
  selectedPage: SeelectedPageType;
  selectPage: (name: SeelectedPageType) => void;
  username: string;
  setUsername: (name: string) => void;
};

export const useMaryFoodStore = create<StoreData>()((set, get) => ({
  selectedPage: "recipe",
  selectPage: (name) =>
    set({
      ...get(),
      selectedPage: name,
    }),
  username: "",
  setUsername: (name: string) =>
    set({
      ...get(),
      username: name,
    }),
}));
