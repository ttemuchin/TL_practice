import { LearningProcess } from "./LearningProcess.model";
import { GroupOfCards } from "../GroupOfCards/GroupOfCards.model";
import { Card } from "../Card/Card.model";

const word1: Card = { id: 1, rusWord: "работать", gerWord: "arbeiten" };
const word2: Card = { id: 2, rusWord: "учиться", gerWord: "studieren" };

describe("LearningProcess", () => {
  describe("moveToLearned", () => {
    const group: GroupOfCards = { id: 1, name: "Favorites", cards: [word1, word2] };

    it("removes first card", () => {
      const group1 = LearningProcess.moveToLearned(group);
      expect(group1.cards).toEqual([word2]);
    });
    it("removes all cards", () => {
      let group1 = LearningProcess.moveToLearned(group);
      group1 = LearningProcess.moveToLearned(group1);
      expect(group1.cards).toEqual([]);
      // const group2 = LearningProcess.moveToLearned(group1);
      // expect(group2.cards).toEqual([]);
    });
  });

  describe("moveToUnknown", () => {
    const group: GroupOfCards = { id: 1, name: "Favorites", cards: [word1, word2] };

    it("places the first card to the end of group", () => {
      const group1 = LearningProcess.moveToUnknown(group);
      expect(group1.cards).toEqual([word2, word1]);
    });

    it("should return original list", () => {
      let group1 = LearningProcess.moveToUnknown(group);
      group1 = LearningProcess.moveToUnknown(group1);
      expect(group1.cards).toEqual(group.cards);
    });
  });
});
