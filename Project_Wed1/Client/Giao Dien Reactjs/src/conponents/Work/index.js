import React, { useState } from "react";
import { CardDeck, Container, Row } from "react-bootstrap";
import ApplicationForm from "./ApplicationForm";
import JobItem from "./JobItem";

const Job = props => {
    const initState = [
        {
            name: "Strawberries pickers, weeding, pruning & other farm work",
            descriptions: [
                "10 people needed ASAP",
                "Contract paid@ $.55/kg",
                "Approximately $100-150 a day",
                "No waiting lis",
                "Work eligible for 2nd year visa",
                "Bundaberg North",
                "Season: April to September",
                "CLOSED"
            ],
            images: [
                {
                    src: "./../images/Work/Targo_Images/Strawberry.png",
                    alt: " Strawberry"
                },
                {
                    src: "./../images/Work/Targo_Images/Strawberry1.png",
                    alt: " Strawberry 1"
                }
            ]
        },
        {
            name: "Zucchini picking",
            descriptions: [
                "10 people needed ASAP",
                "Contract paid@ $.55/kg",
                "Approximately $100-150 a day",
                "No waiting lis",
                "Work eligible for 2nd year visa",
                "Bundaberg North",
                "Season: April to September",
                "CLOSED"
            ],
            images: [
                {
                    src: "./../images/Work/Targo_Images/zuchini.png",
                    alt: " Zuchini"
                },
                {
                    src: "./../images/Work/Targo_Images/zucchini1.png",
                    alt: " Zuchini 1"
                },
                {
                    src: "./../images/Work/Targo_Images/zucchini2.png",
                    alt: " Zuchini 2"
                }
            ]
        },
        {
            name: "Tomatoes picking, weeding, pruning & other farm work",
            descriptions: [
                "10 people needed ASAP",
                "Contract paid@ $.55/kg",
                "Approximately $100-150 a day",
                "No waiting lis",
                "Work eligible for 2nd year visa",
                "Bundaberg North",
                "Season: April to September",
                "CLOSED"
            ],
            images: [
                {
                    src: "./../images/Work/Targo_Images/Tomatoes.png",
                    alt: " Tomatoes"
                },
                {
                    src: "./../images/Work/Targo_Images/Tomatoes1.png",
                    alt: " Tomatoes 1"
                },
                {
                    src: "./../images/Work/Targo_Images/Tomatoes2.png",
                    alt: " Tomatoes 2"
                }
            ]
        }
    ];
    const [state, setState] = useState(initState);
    const jobs = state.map((job, i) => {
        return <JobItem key={i} {...job} />;
    });
    return (
        <>
            <Container fluid={true}>
                <h1 className="text-warning p-1 mt-3"><i className="fa fa-briefcase"></i>Frequently asked quetions</h1>
                <CardDeck>{jobs}</CardDeck>
            </Container>
            <ApplicationForm />
        </>
    );
};
export default Job;
