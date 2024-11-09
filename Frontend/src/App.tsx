import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import AuthAndRegisterMenu from "./components/AuthAndRegisterMenu/AuthAndRegisteMenu";
import { useState } from "react";
import UserProfile from "./components/UserProfile/UserProfile";

function App() {
  const [menuVisible, setMenuVisible] = useState(false);
  const [profileVisible, setProfileVisible] = useState(true);

  return (
    <BrowserRouter>
      <Header></Header>
      {menuVisible ? (
        <AuthAndRegisterMenu
          exit={() => setMenuVisible(false)}
        ></AuthAndRegisterMenu>
      ) : null}
      {profileVisible ? (
        <UserProfile exit={() => setProfileVisible(false)} />
      ) : null}
      <Routes>
        {/* <Route path="/user-profile" element={<UserProfile />}></Route> */}
      </Routes>
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
