import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import CreateRecipe from "./components/CreateRecipe/CreateRecipe";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<CreateRecipe />}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
