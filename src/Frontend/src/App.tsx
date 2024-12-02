import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import AuthAndRegisterMenu from "./components/AuthAndRegisterMenu/AuthAndRegisteMenu";
import { useState } from "react";
import UserProfile from "./components/UserProfile/UserProfile";
import { Logout } from "./services/UserServices";
import RecipeEditor from "./components/RecipeEditor/RecipeEditor";
import RecipePage from "./components/RecipePage/RecipePage";

function App() {
  const [menuVisible, setMenuVisible] = useState(false);
  const [profileVisible, setProfileVisible] = useState(false);

  return (
    <BrowserRouter>
      <Header
        OpenRegAndAuthMenu={() => setMenuVisible(true)}
        OpenUserProfile={() => setProfileVisible(true)}
        Logout={() => {
          Logout();
          setProfileVisible(false);
        }}
      ></Header>
      {menuVisible ? (
        <AuthAndRegisterMenu
          exit={() => setMenuVisible(false)}
        ></AuthAndRegisterMenu>
      ) : null}
      {profileVisible ? (
        <UserProfile exit={() => setProfileVisible(false)} />
      ) : null}
      {menuVisible || profileVisible ? null : (
        <Routes>
          <Route
            path="create-recipe"
            element={
              <RecipeEditor
                title="Добавить новый рецепт"
                btnStr="Опубликовать"
                onClick={(data) => console.log(data)}
              />
            }
          ></Route>
          <Route path="recipe" element={<RecipePage></RecipePage>}></Route>
        </Routes>
      )}
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
