import { create } from "zustand";

type StoreData = {
  username: string;
  setUsername: (name: string) => void;
};

export const useMaryFoodStore = create<StoreData>()((set, get) => ({
  username: localStorage.getItem("username") ?? "",
  setUsername: (name: string) => {
    if (name === "") {
      localStorage.removeItem("username");
    } else {
      localStorage.setItem("username", name);
    }

    set({
      ...get(),
      username: name,
    });
  },
}));
