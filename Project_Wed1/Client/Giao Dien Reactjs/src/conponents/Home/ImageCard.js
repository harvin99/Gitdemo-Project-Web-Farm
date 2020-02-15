import React, { useState } from "react";
import { Button, CardDeck, Card, Row, Col, Modal } from "react-bootstrap";
const ImageCard = props => {
    const initimageState = {
        list: [
            {
                src: "./../images/LandingPage/Targo_Images/021.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/032.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/049.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/067.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/IMG_6649.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/IMG_6652.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/IMG_6653.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/IMG_7913.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/Group.jpg",
                alt: "0",
                showModal: false
            },

            {
                src: "./../images/LandingPage/Targo_Images/IMG_8031.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/IMG_8043.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/124.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/Aerial1.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/Aerial2.jpg",
                alt: "0",
                showModal: false
            },
            {
                src: "./../images/LandingPage/Targo_Images/IMG_8008.jpg",
                alt: "0",
                showModal: false
            }
        ]
    };
    const [modalState, setmodalState] = useState({ show: false, index: 0 });

    const [imageState, setCardimageState] = useState(initimageState);
    const onClickImage = i => {
        setmodalState({ show: true, index: i });
    };
    const imgList = imageState.list.map((item, i) => {
        return (
            <Col
                lg={3}
                md={6}
                sm={12}
                key={i}
                className="mb-4"
                onClick={() => onClickImage(i)}
            >
                {" "}
                <img
                    src={item.src}
                    alt={item.alt}
                    className="img-fluid img-thumbnail"
                />
            </Col>
        );
    });
    const ImageModal = imageState.list[modalState.index];
    return (
        <>
            <Card className="text-center m-5 rounded">
                <Card.Header>
                    <h4>Image</h4>
                </Card.Header>
                <Card.Body>
                    <Row className = "mt-4">{imgList}</Row>
                </Card.Body>
            </Card>
            <Modal
                show={modalState.show}
                onHide={() => setmodalState({ show: false, index: 0 })}
            >
                {/* <Modal.Header closeButton>
                    <Modal.Title>{ImageModal.alt}</Modal.Title>
                </Modal.Header> */}
                <Modal.Body>
                    <img
                        src={ImageModal.src}
                        alt={ImageModal.alt}
                        className="img-fluid img-thumbnail"
                    />
                </Modal.Body>
            </Modal>
        </>
    );
};
export default ImageCard;
