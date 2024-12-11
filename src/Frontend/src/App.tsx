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
