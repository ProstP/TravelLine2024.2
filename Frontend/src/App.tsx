import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import CreateRecipe from "./components/CreateRecipe/CreateRecipe";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";

function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <Routes>
        {/* <Route path="/create-recipe" element={<CreateRecipe />}></Route> */}
        <Route path="/" element={<CreateRecipe />}></Route>
      </Routes>
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
