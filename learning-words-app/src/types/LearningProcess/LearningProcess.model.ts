import { GroupOfCards } from "../GroupOfCards/GroupOfCards.model";
//import { Card } from "../Card/Card.model";

export type LearningProcess = {
  group: GroupOfCards;
  //learnedCards: Card[];
  //unknownCards: Card[] = group.cards;
};

//export const checkAnswer = ()
//понял что некруто создавать лишние структуры данных, можно же обрезать массив..
// и проверять ответ - бесполезный метод, просто в нужном месте вызываем один из этих
export const moveToLearned = (group: GroupOfCards): GroupOfCards => {
  return {
    ...group,
    cards: group.cards.slice(1),
  };
};

export const moveToUnknown = (group: GroupOfCards): GroupOfCards => {
  return {
    ...group,
    cards: [...group.cards.slice(1), group.cards[0]],
  };
};

export const LearningProcess = { moveToLearned, moveToUnknown };
