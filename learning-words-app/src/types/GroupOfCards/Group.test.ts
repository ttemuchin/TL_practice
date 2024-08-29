import { Card } from "../Card/Card";
import { GroupOfCards } from "./GroupOfCards";

describe("", () => {
  describe("createCard", () => {
    const group1: GroupOfCards = { id: "1", name: "favorites", cards: [] };
    const group2: GroupOfCards = { id: "2", name: "start learning german", cards: [] };
    // eslint-disable-next-line prefer-const
    let allGroups: GroupOfCards[] = [group1, group2];

    it("creates new group", () => {
      expect(GroupOfCards.createGroup(allGroups, "3", "new one", [])).toContainEqual({
        id: "3",
        name: "new one",
        cards: [],
      });
    });
    it("doesnt create a group with empty id or name", () => {
      expect(GroupOfCards.createGroup(allGroups, "", "new one", []).at(-1)).toEqual(group2);
      expect(GroupOfCards.createGroup(allGroups, "3", "", []).at(-1)).toEqual(group2);
    });
  });

  describe("getGroupById", () => {
    const group1: GroupOfCards = { id: "1", name: "favorites", cards: [] };
    const group2: GroupOfCards = { id: "2", name: "start learning german", cards: [] };
    const allGroups: GroupOfCards[] = [group1, group2];

    it("returns 2nd group", () => {
      expect(GroupOfCards.getGroupById(allGroups, "2")).toEqual(group2);
    });
    it("returns undefined", () => {
      expect(GroupOfCards.getGroupById(allGroups, "3")).toEqual(undefined);
    });
  });

  describe("chooseCards", () => {
    const word1: Card = { id: "1", rusWord: "работать", translation: "arbeiten" };
    const word2: Card = { id: "2", rusWord: "учиться", translation: "studieren" };
    const word3: Card = { id: "3", rusWord: "говорить", translation: "sprechen" };
    const dict: Card[] = [word1, word2, word3];
    const cardsId: string[] = ["1", "3"];
    const group: GroupOfCards = { id: "3", name: "firstGroup", cards: [] };

    it("places cards in the group", () => {
      expect(GroupOfCards.chooseCards(dict, cardsId, group)).toEqual({
        id: "3",
        name: "firstGroup",
        cards: [word1, word3],
      });
    });
  });
});
