import "./App.css";
import { Routes, Route } from "react-router-dom";
import LearningProcess from "./Components/Pages/LearningProcess";
import MainPage from "./Components/Pages/MainPage";
import NotFoundPage from "./Components/Pages/NotFoundPage";
import Menu from "./Components/Menu";
import { GroupOfCards } from "./types/GroupOfCards/GroupOfCards";

const group1: GroupOfCards = {
  id: "1",
  name: "Время суток",
  cards: [
    { id: "1", rusWord: "День", translation: "Tag" },
    { id: "2", rusWord: "Ночь", translation: "Nacht" },
    { id: "3", rusWord: "Вечер", translation: "Abend" },
    { id: "3", rusWord: "Утро", translation: "Morgen" },
  ],
};

function App() {
  return (
    <>
      <Menu></Menu>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/learn" element={<LearningProcess cards={group1.cards} />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
      {/* <div>
        <LearningProcess cards={group1.cards}></LearningProcess>
      </div> */}
    </>
  );
}

export default App;
