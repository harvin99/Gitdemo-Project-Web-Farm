import React, { useState } from "react";
import { Container, Card, CardDeck, Row } from "react-bootstrap";
import DiscountItem from "./DiscountsItem";

const Discount = props => {
    const initState = [
        {
            imgSrc: "./../images/Discounts/Targo_Images/nab-whj600x3601.jpg",
            headerCard: "Fee Free NAB Bank Account Setup",
            bodyCard: "The National Australia Bank Group has over 12,000,000 customers and 50,000 people, operating more than 1,750 stores and Service Centres globally. There's 3400 NAB ATMs and rediATMs throughout Australia and best of all you'll never pay monthly fees when banking with NAB."
        },
        {
            imgSrc: "./../images/Discounts/Targo_Images/taxback-tfn-whj600x360.jpg",
            headerCard: "Free Tax File Number Setup Service",
            bodyCard: "Tax File Number Setup Do you want your Tax File Number setup the day you arrive into Australia? Taxback.com offer this premium service for Free to all Premium Members.Take the hassle out of Taxation, get your Tax File Number setup quickly and easily while you can hit the beach instead. This service normally cost $30."
        },
        {
            imgSrc: "./../images/Discounts/Targo_Images/greyhound-whj600x360.jpg",
            headerCard: "15% Discount on Greyhound Bus Tickets",
            bodyCard: "Greyhound provide comfortable, hassle-free, and affordable coach services across all corners of Australia and are Australia's only national coach service. As a premium member you'll receive up to 15% off on all bus passes around Australia."
        }
    ];

    const [state, setState] = useState(initState);
    const Discounts = state.map((discountItem, i) => {
        return (
            <DiscountItem {...discountItem} key={i} />
        );
    });
    return (
        <Container fluid={true}>
            <div className="bg-light p-5 mt-4">
                <h1 className="text-warning">
                    <i class="fa fa-tags"></i>Discounts & Benefits
                </h1>
                <p>
                    <b>What can you expect as a number of our hostel</b>
                </p>
            </div>
            <CardDeck className = "mt-4 mb-4">
                {/* <Row>
                    {Discounts}
                </Row> */}
                 {Discounts}
            </CardDeck>
        </Container>
    );
};
export default Discount;
