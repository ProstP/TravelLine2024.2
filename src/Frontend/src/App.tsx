<<<<<<< HEAD
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import AuthAndRegisterMenu from "./components/AuthAndRegisterMenu/AuthAndRegisteMenu";
import { useState } from "react";
import UserProfile from "./components/UserProfile/UserProfile";
import { Logout } from "./core/services/UserServices";

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
=======
import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
>>>>>>> 231e229 (Сделал команду для создания рецептов)
  );
}

export default App;
