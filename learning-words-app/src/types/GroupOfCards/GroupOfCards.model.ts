import { Card } from "../Card/Card.model";

export type GroupOfCards = {
  id: number;
  name: string;
  cards: Card[];
};

export const createGroup = (groups: GroupOfCards[], group: GroupOfCards): GroupOfCards[] => {
  return [...groups, group];
};

export const editGroup = (group: GroupOfCards, rename: string): GroupOfCards => {
  if (rename === "") {
    return group;
  }
  return {
    ...group,
    name: rename,
  };
};

export const chooseCards = (dictionary: Card[], selectedCards: number[], group: GroupOfCards): GroupOfCards => {
  group.cards = dictionary.filter((card) => selectedCards.includes(card.id));

  return group;
};

export const deleteGroup = (groups: GroupOfCards[], id: number): GroupOfCards[] => {
  return groups.filter((group) => group.id !== id);
};

export const getGroupById = (groups: GroupOfCards[], id: number): GroupOfCards | undefined => {
  return groups.find((group) => group.id === id);
};

export const Deck = { createGroup, editGroup, deleteGroup, getGroupById, chooseCards };
