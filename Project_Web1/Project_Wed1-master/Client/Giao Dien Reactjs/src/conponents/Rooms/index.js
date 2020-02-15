import React, { useState } from "react";
import RoomItem from "./RoomItem";
import BookRoom from "./BookRoom";
import { Container } from "react-bootstrap";

const Room = props => {
    const initRoom = [
        {
            Id: 1,
            Name: "Deluxe 6 Bed Dorm",
            Available: 6,
            Note: "1 free night when you book 7 nights",
            Price: 12,
            Image: [{ src: "./../images/Room/Targo_Images/20160807_131511.jpg", alt: "" }, { src: "./../images/Room/Targo_Images/20160807_131531.jpg", alt: "" }, { src: "./../images/Room/Targo_Images/20160807_131651.jpg", alt: "" }]
        },
        {
            Id: 2,
            Name: "Deluxe 6 Bed Dorm",
            Available: 6,
            Note: "1 free night when you book 7 nights",
            Price: 12,
            Image: [{ src: "./../images/Room/Targo_Images/20160807_131412.jpg", alt: "" }, { src: "./../images/Room/Targo_Images/20160807_131651.jpg", alt: "" }]
        },
        {
            Id: 3,
            Name: "Deluxe 6 Bed Dorm",
            Available: 6,
            Note: "1 free night when you book 7 nights",
            Price: 12,
            Image: [{ src: "./../images/Room/Targo_Images/tmp_7857-20160909_0845221723216960.jpg", alt: "" }, { src: "./../images/Room/Targo_Images/20160807_131535.jpg", alt: "" }, { src: "./../images/Room/Targo_Images/20160807_131443.jpg", alt: "" }]
        }
    ];
    const initSelectedRoom = {
        Id: 1,
        Name: "Deluxe 6 Bed Dorm",
        Available: 6,
        Note: "1 free night when you book 7 nights",
        Price: 12,
        Image: [{ src: "", alt: "" }, { src: "", alt: "" }, { src: "", alt: "" }]
    }
    const [rooms, SetRoom] = useState(initRoom);
    const [selectedRoom, SetSelectedRoom] = useState(initSelectedRoom)
    const roomList = rooms.map((room, i) => {
        return <RoomItem key={i} {...room} />
    })
    return (
        <Container fluid={true}>
            <div className="container-fluid bg-light mt-4 p-5">
                <h1 className="text-warning">
                    <i className="fa fa-bed m-3" />
                    Rooms &amp; Rates
                </h1>
                <p>
                    <b>
                        Targo Backpackers hostel has a range of rooms available to suit all
                        budgets and group sizes.
                    </b>
                </p>
                <ul>
                    <li>
                        Most rooms are Air Conditioned or with ceiling fans help keep you
                        cool during the summer months.
                    </li>
                    <li>Room are big and roomy with high and comfiest bunks.</li>
                    <li>We have Privates rooms, to 4, 6 to 8 share dorms.</li>
                    <li>
                        We also have holiday homes that cater to families or large groups.
                    </li>
                    <li>
                        We have TV, entertainment areas and dast wifi upto 1GB a day per
                        device that is 30GB a month. So if you're looking for Somewhere to
            Stay in Bundaberg, book in today.{" "}
                    </li>
                </ul>
                <p>
                    The prices are all in Australian Dollars and are subject to change at
                    any time.
                </p>
            </div>
            <table className="table border">
                <thead className="thead-dark border">
                    <tr>
                        <th
                            scope="col"
                            className="border-right border-secondary text-center"
                        >
                            Name
                        </th>
                        <th
                            scope="col"
                            className="border-right border-secondary text-center"
                        >
                            Avaliable
                        </th>
                        <th
                            scope="col"
                            className="border-right border-secondary text-center"
                        >
                            Note
                        </th>
                        <th
                            scope="col"
                            className="border-right border-secondary text-center"
                        >
                            Price
                        </th>
                        <th scope="col" />
                    </tr>
                </thead>
                <tbody>
                    {roomList}
                </tbody>
            </table>
            <BookRoom {...selectedRoom} />
        </Container>
    );
};
export default Room;
