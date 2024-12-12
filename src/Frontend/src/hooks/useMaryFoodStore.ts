import { create } from "zustand";

type StoreData = {
  username: string;
  setUsername: (name: string) => void;
};

export const useMaryFoodStore = create<StoreData>()((set, get) => ({
  username: "",
  setUsername: (name: string) =>
    set({
      ...get(),
      username: name,
    }),
}));
