import "./App.css";
import { Routes, Route } from "react-router-dom";
import LPPage from "./Components/Pages/LPPage";
import MainPage from "./Components/Pages/MainPage";
import NotFoundPage from "./Components/Pages/NotFoundPage";
import Menu from "./Components/Menu/Menu";

function App() {
  return (
    <>
      <Menu></Menu>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/learn" element={<LPPage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </>
  );
}

export default App;
