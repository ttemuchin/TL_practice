import React from "react";
import "./MainPage.scss";
import Dictionary from "../Dictionary/Dictionary";
import GroupList from "../GroupList/GroupList";
import { useState } from "react";

const MainPage: React.FC = () => {
  const [showDictionary, setShowDictionary] = useState(false);
  const [showGroups, setShowGroups] = useState(false);

  const toggleDictionary = () => {
    setShowDictionary((state) => !state);
    setShowGroups(false);
  };

  const toggleGroups = () => {
    setShowGroups((state) => !state);
    setShowDictionary(false);
  };

  return (
    <>
      {/* <div className="main-page"></div>
      <Dictionary /> */}
      <div className="page-container">
        <div className="button-container">
          <button className="main-button" onClick={toggleDictionary}>
            Dictionary
          </button>
          <button className="main-button" onClick={toggleGroups}>
            Groups
          </button>
        </div>
        {showDictionary && <Dictionary />}
        {showGroups && <GroupList />}
      </div>
    </>
  );
};

export default MainPage;
