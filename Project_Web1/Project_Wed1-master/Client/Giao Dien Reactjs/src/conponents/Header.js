import React, { useState } from "react";
import { Navbar, Nav } from "react-bootstrap";
import { Link, withRouter } from 'react-router-dom'
import CartIcon from "./CartIcon";
const Header = withRouter(props => {
    const initNavItem = {
        activeIndex: 0,
        list: [
            { name: "Home", link: "/" },
            { name: "Rooms & Rates", link: "/Rooms" },
            { name: "Work", link: "/Work" },
            { name: "FAQ", link: "/FAQ" },
            { name: "Discounts & Benefits", link: "/Discounts" },
            { name: "Products", link: "/Product" }
        ]
    };
    const activeLink = props.location.pathname;

    const [NavItem, setNavItem] = useState(initNavItem);
    const activeLinkStyle = {
        backgroundColor: '#4DA3FF',
        borderRadius: '5px'
    }
    const navItems = NavItem.list.map((item, i) => {
        return <Link to={item.link} style={(activeLink === item.link) ? activeLinkStyle : {}} className="text-white nav-link" key={i}>{item.name}</Link>
    });
    return (
        <Navbar bg="primary" expand="md">
            <Navbar.Brand href="#home" className="text-white">
                <h4 className="d-inline m-1"><i className="fa fa-briefcase align-middle mr-1"></i></h4><span style={{ fontSize: "16px" }}><b>Targo</b>Backpackers</span>
            </Navbar.Brand>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" className="text-white border-0"><i class="fa fa-bars"></i></Navbar.Toggle>
            <Navbar.Collapse id="responsive-navbar-nav" className="justify-content-end text-center">
                <Nav>
                    {navItems}
                    <CartIcon></CartIcon>
                </Nav>
                
            </Navbar.Collapse>
        </Navbar>
    );
});
export default Header;
