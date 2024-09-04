import React from "react";
import Word from "../Word/Word";
import { useState } from "react";
import { Card } from "../../types/Card/Card";
import "./Dictionary.scss";

const Dictionary: React.FC = () => {
  const [cards, setCards] = useState<Card[]>([
    { id: "1", rusWord: "ru1", translation: "ger1" },
    { id: "2", rusWord: "ru2", translation: "ger2" },
  ]);

  const handleEdit = (updatedCard: Card) => {
    const newCards = cards.map((card) => (card.id === updatedCard.id ? updatedCard : card));
    setCards(newCards);
  };

  const handleDelete = (cardId: string) => {
    const newCards = Card.dropCard(cards, cardId);
    setCards(newCards);
  };

  return (
    <>
      <div className="dictionary">
        {/* <Word card={{ id: "1", rusWord: "я", translation: "ich" }}></Word> */}
        {cards.map((card) => (
          <Word key={card.id} card={card} onEdit={handleEdit} onDelete={handleDelete} />
        ))}
      </div>
    </>
  );
};

export default Dictionary;
