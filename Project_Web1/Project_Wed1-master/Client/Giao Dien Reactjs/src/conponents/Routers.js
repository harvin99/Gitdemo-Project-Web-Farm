import React, { useState } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Home from "./Home/index";
import Help from "./Help";
import FAQ from "./FAQ";
import Discount from "./Discounts";
import Job from "./Work";
import Room from "./Rooms";
import ErrorPage from "./404";
import Product from "./Product"
const Routers = props => {

    return (
        <Switch>
            <Route path="/" exact>
                <Home />
            </Route>
            <Route path="/Rooms">
                <Room />
            </Route>
            <Route path="/Work">
                <Job />
            </Route>
            <Route path="/FAQ">
                <FAQ />
            </Route>
            <Route path="/Discounts">
                <Discount />
            </Route>
            <Route path="/Product">
                <Product />
            </Route>
            <Route><ErrorPage /></Route>
        </Switch>
    );
};

export default Routers;
