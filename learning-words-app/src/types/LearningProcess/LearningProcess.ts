import { Card } from "../Card/Card";

export type LearningProcess = {
  group: Card[];
};

export const moveToLearned = (group: Card[]): Card[] => {
  return group.slice(1);
};

export const moveToUnknown = (group: Card[]): Card[] => {
  const unknownCard: Card = group[0];
  group = [...group.slice(1), unknownCard];
  return group;
};

export const LearningProcess = { moveToLearned, moveToUnknown };
