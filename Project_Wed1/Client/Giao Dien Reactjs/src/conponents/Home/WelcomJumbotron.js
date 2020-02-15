import React, { useState } from "react";
import { Button,Jumbotron } from "react-bootstrap";
const WelcomJumbotron = props => {
  const initWelComState = {
    title: "WELCOM TO TARGO BACKPACKER HOSTEL",
    description:
      "We are located centrally, about 4 hours from Brisbane. Cheep alternative accomondations for holiday makers and for those who are keen on making money while traveling. We provide trusted and well paid regional farm work all year around. We have many friendly and committed staff that will assist in finding a job farm with no to short waiting list. For holiday makers, Bundaberg has lots to offer from Sand, Sun, Sonorkel, to turtle tours."
  };
  const [welcomState, setWelcomState] = useState(initWelComState);
  
  return(
      <Jumbotron className="mt-4">
          <h1 className="display-4">{welcomState.title}</h1>
          <p className="lead">{welcomState.description}</p>
          <hr className="my-4"/>
          <p>We offer accommodation with holiday deals and event guide to all explorers out there.</p>
            <div className="text-center">
                <Button variant="primary" href="/" className="mr-5">Book a Room</Button>
                <Button variant="primary" href="/" className="ml-5">Apply for job</Button>
            </div>
      </Jumbotron>
  )
};
export default WelcomJumbotron;
