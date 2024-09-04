import React from "react";
import "./MainPage.scss";
import { Link, Outlet } from "react-router-dom";

const MainPage: React.FC = () => {
  // const [showButtons, setShowButtons] = useState(true);

  // const removeButtons = () => {
  //   setShowButtons(false);
  // }; не нужная штука(( но как обновить стейт.. из словаря идем на мейн, setShowButtons(true)

  return (
    <>
      <div className="page-container">
        <div className="button-container">
          <Link to="dictionary">
            <button className="main-button">Dictionary</button>
          </Link>
          <Link to="groups">
            <button className="main-button">Groups</button>
          </Link>
        </div>
        <Outlet />
      </div>
    </>
  );
};

export default MainPage;
