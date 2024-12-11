import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import UserProfile from "./components/UserProfile/UserProfile";
import { Logout } from "./services/UserServices";
import RecipeEditor from "./components/RecipeEditor/RecipeEditor";
import RecipePage from "./components/RecipePage/RecipePage";
import AuthenticationMenu from "./components/AuthAndRegisterMenu/AuthenticationMenu/AuthenticationMenu";
import RegisterMenu from "./components/AuthAndRegisterMenu/RegisterMenu/RegisterMenu";

function App() {
  return (
    <BrowserRouter>
      <Header
        Logout={() => {
          Logout();
        }}
      ></Header>
      <Routes>
        <Route
          path="user-profile"
          element={<UserProfile></UserProfile>}
        ></Route>
        <Route
          path="auth"
          element={<AuthenticationMenu></AuthenticationMenu>}
        ></Route>
        <Route path="register" element={<RegisterMenu></RegisterMenu>}></Route>
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
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
