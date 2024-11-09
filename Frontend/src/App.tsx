import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import AuthenticationMenu from "./components/AuthenticationMenu/AuthenticationMenu";
import RegisterMenu from "./components/RegisterMenu/RegisterMenu";

function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <Routes>
        <Route
          path="/auth"
          element={
            <AuthenticationMenu
              exit={() => console.log("Exit")}
              login={() => console.log("login")}
              toRegister={() => console.log("To regester")}
            />
          }
        ></Route>
        <Route
          path="/register"
          element={
            <RegisterMenu
              exit={() => console.log("Exit")}
              register={() => console.log("register")}
              toLogin={() => console.log("To login")}
            />
          }
        ></Route>
      </Routes>
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
