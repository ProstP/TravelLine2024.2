import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import UserProfile from "./components/UserProfile/UserProfile";
import { Logout } from "./services/UserServices";
import RecipePage from "./components/RecipePage/RecipePage";
import AuthenticationMenu from "./components/AuthAndRegisterMenu/AuthenticationMenu/AuthenticationMenu";
import RegisterMenu from "./components/AuthAndRegisterMenu/RegisterMenu/RegisterMenu";
import RecipeCreator from "./components/RecipeCreator/RecipeCreator";
import RecipeListPage from "./components/RecipeListPage/RecipeListPage";
import { useMaryFoodStore } from "./hooks/useMaryFoodStore";
import FavouriteList from "./components/FavouriteList/FavouriteList";
import Main from "./components/Main/Main";

function App() {
  const setName = useMaryFoodStore((store) => store.setUsername);

  return (
    <BrowserRouter>
      <Header
        Logout={() => {
          Logout();
          setName("");
        }}
      ></Header>
      <Routes>
        <Route path="/" element={<Main></Main>}></Route>
        <Route
          path="/recipes"
          element={<RecipeListPage></RecipeListPage>}
        ></Route>
        <Route
          path="/favourite"
          element={<FavouriteList></FavouriteList>}
        ></Route>
        <Route
          path="/user-profile"
          element={<UserProfile></UserProfile>}
        ></Route>
        <Route
          path="/auth"
          element={<AuthenticationMenu></AuthenticationMenu>}
        ></Route>
        <Route path="/register" element={<RegisterMenu></RegisterMenu>}></Route>
        <Route
          path="/create-recipe"
          element={<RecipeCreator></RecipeCreator>}
        ></Route>
        <Route path="/recipe">
          <Route path=":id" element={<RecipePage></RecipePage>}></Route>
        </Route>
      </Routes>
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
