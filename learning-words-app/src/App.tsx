//import tglogo from "./assets/Telegram_logo.svg";
import "./App.css";
import LearningProcess from "./Components/LearningProcess";
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
      {/* <a href="https://t.me/ttemuchin4">
        <img src={tglogo} className="logo" alt="telegram logo" />
      </a> */}
      <Menu></Menu>
      <div>
        <LearningProcess cards={group1.cards}></LearningProcess>
      </div>
    </>
  );
}

export default App;
