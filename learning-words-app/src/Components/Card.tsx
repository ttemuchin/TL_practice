import { Card as CardType } from "../types/Card/Card";
import React from "react";
import "./Card.scss";

type CardProps = {
  card: CardType;
  showTranslation: boolean;
};

const Card: React.FC<CardProps> = ({ card, showTranslation }) => {
  //   const [showTranslation, setShowTranslation] = useState(false);

  //   const flipCard = () => {
  //     setShowTranslation(!showTranslation);
  //   }; +++onClick={flipCard}

  return (
    <div className={`card ${showTranslation ? "flipped" : ""}`}>
      <div className="card-content">{showTranslation ? card.translation : card.rusWord}</div>
    </div>
  );
};

export default Card;
