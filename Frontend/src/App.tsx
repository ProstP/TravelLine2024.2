import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import AuthAndRegisterMenu from "./components/AuthAndRegisterMenu/AuthAndRegisteMenu";
import { useState } from "react";
import UserProfile from "./components/UserProfile/UserProfile";
import { Logout } from "./services/UserServices";

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
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
