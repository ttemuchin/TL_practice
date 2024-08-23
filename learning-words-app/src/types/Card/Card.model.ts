export type Card = {
  id: number;
  rusWord: string;
  gerWord: string;
};

export const createCard = (dictionary: Card[], newCard: Card): Card[] => {
  return [...dictionary, newCard];
};

export const dropCard = (dictionary: Card[], cardId: number): Card[] => {
  return dictionary.filter((card) => card.id !== cardId);
};

export const getCardById = (dictionary: Card[], cardId: number): Card | undefined => {
  return dictionary.find((card) => card.id === cardId);
};

export const editCard = (card: Card, newRus: string, newGer: string): Card => {
  if (newRus === "" || newGer === "") {
    return card;
  }

  return {
    ...card,
    rusWord: newRus,
    gerWord: newGer,
  };
};

export const Card = { createCard, dropCard, getCardById, editCard };
