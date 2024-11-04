import { create } from "zustand";

type SeelectedPageType = "main" | "recipe" | "favourite";

type StoreData = {
  selectedPage: SeelectedPageType;
  selectPage: (name: SeelectedPageType) => void;
};

export const useMaryFoodStore = create<StoreData>()((set, get) => ({
  selectedPage: "recipe",
  selectPage: (name) =>
    set({
      ...get(),
      selectedPage: name,
    }),
}));
