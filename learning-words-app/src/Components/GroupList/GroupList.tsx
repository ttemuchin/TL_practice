import React from "react";
import { GroupOfCards } from "../../types/GroupOfCards/GroupOfCards";

const groupsData: GroupOfCards[] = [
  { id: "1", name: "group1", cards: [] },
  { id: "2", name: "group2", cards: [] },
  { id: "3", name: "group3", cards: [] },
];

const GroupList: React.FC = () => {
  return (
    <div className="content">
      <h3>Your groups:</h3>
      <div>
        {groupsData.map((group) => (
          <div key={group.id}>{group.name}</div>
        ))}
      </div>
    </div>
  );
};

export default GroupList;
