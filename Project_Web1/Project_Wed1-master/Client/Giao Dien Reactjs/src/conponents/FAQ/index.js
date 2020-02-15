import React, { useState } from "react";
import { Container } from "react-bootstrap";

const FAQ = props => {
    const initFaqs = [
        {
            question: "Our hostel address?",
            answer: "TARGO Backpacker Hostel. 150 Targo street Bundaber Qld."
        },

        {
            question: "What work do you have going on at the moment?",
            answer: "At the moment we have picking strawberries. Then after strawberries we have lychees the after lychees then we have mangoes."
        },

        {
            question: "How much can a person pick per day in average?",
            answer: " With strawberries currently a person can pick from 200kg to 600kg and on average person can pick 300kg a day."
        },

        {
            question: "When does strawberry season end?",
            answer: "SEPTEMBER/ NOVEMBER."
        },

        {
            question: "How many days a week will we work and how many hours a day?",
            answer: "At the moment we work 5 to 6 days a week. About 6-9 hours a day from 6am to fpm. Depending on the  weather."
        },

        {
            question: "Is the accommodation for boys and girls separate?",
            answer: "The accommodation is girl and boys are seperate."
        },

        {
            question: "Is the accommodation rate inclusive of the utilities, internet and other amenities?",
            answer: "Accomodation include rates and all ultilities and amenties include wifi."
        },

        {
            question: "How about food?",
            answer: "You have you get your own food."
        },
        {
            question: "Transport from accomodation to work?",
            answer: "Is $5 a person including drop off and pick up."
        },

        {
            question: "How I can get my salary will it paying everyday or weekly payment?",
            answer: "SALARY will be paid weekly in Cash envelopes or direct deposit depending on the contractors."
        }

    ];
    const [faqs, setFaqs] = useState(initFaqs);
    const listFaqs = faqs.map((faq, i) => {
        return (
            <li key={i}>
                <h6>{faq.question}</h6>
                <p>{faq.answer}</p>
            </li>
        )
    })
    return (
        <Container fluid={true}>
            <div className="m-4 bg-light p-5">
                <h1 className="text-warning">
                    <i className="fa fa-comments"></i>Frequently asked quetions
                </h1>
                <ol>
                    {listFaqs}
                </ol>
            </div>
        </Container>
    );
};
export default FAQ;
