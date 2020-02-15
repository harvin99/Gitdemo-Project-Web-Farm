import React, { useState } from "react";
import { Button, CardDeck, Card } from "react-bootstrap";
const Information = props => {
    const initCardItems = {
        list: [
            {
                title: "About Bundaberg",
                description:
                    "A town that is quality for people who want to re apply their visa quickly by getting 88 days farm word. As soon as this 88 days are don, tou can reapply for your 2nd year visa and continue on your traveling journey."
            }, {
                title: "Working place",
                description:
                    "Near major shooping centre: Hinkler shoopping centre. You would normally don't need car. Ashort stroll is enough to bundaberg city center. Work are provided all year around friend staff. Working along side with the most pretigious farms in bundaber such ass SSS Strawberries lychee farm & mangoes."
            },
            {
                title: "Work and paid",
                description:
                    "Providing great piece rates for those who are keen to work hard a your potential allowed. Employee gets paid for the amount piked, paked, pruned or made on hourly or weekly. An employee can be hired to work a mix of piece rates and hourly rate shift. Certain pay rates range from $19.90 to $25 per hour."
            },
        ]
    };
    const [CardItems, setCardItems] = useState(initCardItems);
    return (
        <CardDeck className="mt-4 text-white text-center">
            <Card bg="success">
                <Card.Body>
                    <i class="fa fa-info display-4"></i>
                    <h2 className="mt-4 mb-4">{CardItems.list[0].title}</h2>
                    <Card.Text className = "text-left">{CardItems.list[0].description}</Card.Text>
                </Card.Body>
            </Card>
            <Card bg="danger">
                <Card.Body>
                    <i class="fa fa-map-marker display-4"></i>
                    <h2 className="mt-4 mb-4">{CardItems.list[1].title}</h2>
                    <Card.Text className = "text-left">{CardItems.list[1].description}</Card.Text>
                </Card.Body>
            </Card>
            <Card bg="warning">
                <Card.Body>
                    <i class="fa fa-credit-card display-4"></i>
                    <h2 className="mt-4 mb-4">{CardItems.list[2].title}</h2>
                    <Card.Text className = "text-left">{CardItems.list[2].description}</Card.Text>
                </Card.Body>
            </Card>
        </CardDeck>

    )

};
export default Information;
