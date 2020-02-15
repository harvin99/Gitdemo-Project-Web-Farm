import React, { useState } from "react";
import { Row, Col, Form, Button } from "react-bootstrap";
import { Link } from 'react-router-dom'
const Footer = props => {
    const initFooterState = {
        activeIndex: 0,
        linkList: [
            { name: "Home", link: "/" },
            { name: "Rooms & Rates", link: "/Rooms" },
            { name: "Work", link: "/Work" },
            { name: "FAQ", link: "/FAQ" },
            { name: "Discounts & Benefits", link: "/Discounts" }
        ]
    };
    const [footerState, setFooterState] = useState(initFooterState);
    const initFormAttr = {
        Fullname: "",
        Email: ""
    }
    const [formAttr, setFormAttr] = useState(initFormAttr);
    const handleChange = (e) => {
        setFormAttr({
            ...formAttr,
            [e.target.name]: e.target.value
        })
    }
    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(formAttr)
    }
    const quickLinks = footerState.linkList.map((item, i) => {
        return (
            <li key={i}>
                <Link to={item.link} className="text-white">{item.name}</Link>
            </li>
        );
    });
    return (
        <div className="m-4 bg-primary text-white" >
            <Row className = "p-2">
                <Col md={4} lg={6} sm={12}>
                    <h1>Quick Links</h1>
                    <ul style={{ listStyleType: "none" }} ><b>{quickLinks}</b></ul>
                </Col>
                <Col>
                    <Form onSubmit={handleSubmit}>
                        <h1>Newsletter</h1>
                        <Form.Group controlId="">
                            <Form.Label>Full Name</Form.Label>
                            <Form.Control name="Fullname" value={formAttr.Fullname} onChange={handleChange} type="text" placeholder="Enter full name" />
                        </Form.Group>
                        <Form.Group controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control name="Email" value={formAttr.Email} onChange={handleChange} type="email" placeholder="Enter email" />
                        </Form.Group>
                        <Button type="submit" variant="outline-light" className="text-white">
                        <i class="fa fa-envelope mr-2"></i>Subscribe</Button>
                    </Form>
                </Col>
            </Row>
            <div className="justify-content-center p-1 text-center" style={{background : "#0475EF"}}> <span>Work of HSH team 2019</span></div>
        </div>
    );
};
export default Footer;
