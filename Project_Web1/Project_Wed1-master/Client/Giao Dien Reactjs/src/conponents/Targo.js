import React from "react";
import { BrowserRouter as Router, Link } from "react-router-dom";
import Routers from "./Routers";
import Header from "./Header";

const Targo = props => {
  return (
    <Router>
      <div className="App">
      <Header/>
        <Routers />
      </div>
    </Router>
  );
};

export default Targo;
