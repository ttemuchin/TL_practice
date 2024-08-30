import { Link } from "react-router-dom";
import "./Menu.scss";

const Menu = () => {
  return (
    <div className="menu">
      <div className="menu-items">
        <Link to="/">Main</Link>
        <Link to="/learn">Learning</Link>
        {/* <a href="#item1" className="menu-item"></a> */}
        {/* <a href="#item2" className="menu-item"></a>
        <a href="#item3" className="menu-item"></a> */}
      </div>
    </div>
  );
};

export default Menu;
