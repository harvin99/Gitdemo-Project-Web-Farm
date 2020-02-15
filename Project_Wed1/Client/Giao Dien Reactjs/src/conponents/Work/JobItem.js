import React, { useState } from 'react';
import ImageCarousel from './ImageCarousel';
import { Col, Card, Button } from 'react-bootstrap';

const JobItem = (props) => {
    const { name, descriptions, images } = props;
    const Descriptions = descriptions.map((description, i) => {
        return (<li key={i}><p className = "m-0">{description}</p></li>)
    })
    return (
        // <Col lg={4} md={6} sm={12} className="mt-4 p-0" style = {{height : "100%"}}>
            <Card className="mt-3">
                <ImageCarousel images={images} />
                <Card.Body>
                    <p><b>{name}</b></p>
                    <ul>
                        {Descriptions}
                    </ul>
                </Card.Body>
                <Card.Footer className="text-center">
                    <Button variant="primary">Apply now</Button>
                </Card.Footer>
            </Card>
        // </Col>
    )
}
export default JobItem