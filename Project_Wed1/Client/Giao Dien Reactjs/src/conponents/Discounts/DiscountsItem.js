import React from "react";
import { Card, Col } from "react-bootstrap";
const DiscountItem = ({ imgSrc, headerCard, bodyCard }) => {
    return (
        // <Col lg={4} md={6} sm={12} className="mt-4">
            <Card>
                <Card.Header>
                    {headerCard}
                </Card.Header>
                <Card.Body>
                    <img
                        className="img-fluid img-thumbnail"
                        src={imgSrc}
                        alt={headerCard}
                    />
                    <Card.Text>{bodyCard}</Card.Text>
                </Card.Body>
            </Card>
        // </Col>
    );
};
export default DiscountItem;
