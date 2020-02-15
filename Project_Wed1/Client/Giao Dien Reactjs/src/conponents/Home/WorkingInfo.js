import React, { useState } from "react";
import { Button, CardDeck, Card, Row, Col } from "react-bootstrap";
const WorkingInfo = props => {
  const initWorking = {
    img: "./../images/LandingPage/Targo_Images/work.jpg",
    description: "..."
  };
  const [workInfo, setCardWorkInfo] = useState(initWorking);
  return (
    <Card className="m-5 text-center">
      <Card.Header>
        <h4>Working Information</h4>
      </Card.Header>
      <Card.Body>
        <Row>
          <Col md={6} sm={12} className = "align-self-center">
            <img className="img-thumbnail img-fluid" src={workInfo.img} alt="img" />
          </Col>

          <Col md={6} sm={12} className = "text-left">
            {workInfo.description}
          </Col>
        </Row>
      </Card.Body>
      <Card.Footer>
        <Button href="/"> Apply for Job</Button>
      </Card.Footer>
    </Card>
  );
};
export default WorkingInfo;
