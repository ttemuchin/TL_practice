import { GroupOfCards } from "../GroupOfCards/GroupOfCards.model";

export type LearningProcess = {
  group: GroupOfCards;
};

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
