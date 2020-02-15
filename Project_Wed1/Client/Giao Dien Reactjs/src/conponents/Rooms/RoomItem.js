import React from 'react';
import { Button } from 'react-bootstrap'
const RoomItem = ({ Id, Name, Available, Note, Price, Image }) => {
    const units = 'AUD'
    const ImageList = Image.map((Image, i) => {
        return (
            <div key={i} className="col-lg-3" style = {{objectFit :"cover"}}>
                <img style = {{objectFit :"cover"}}
                    className="img-fluid img-thumbnail"
                    src={Image.src}
                    alt={Image.alt}
                    type="button"
                    data-toggle="modal"
                    data-target="#exampleModal4"
                    
                />
            </div>
        )
    })
    return (<>
        <tr className="bg-light">
            <th scope="row" className="border-right text-center">
                {Name}
            </th>
            <td className="text-center border-right">{Available}</td>
            <td className="border-right text-center">
                {Note}
            </td>
            <td className="text-center border-right">{`${units} ${Price}`}</td>
            <td className="text-center">
                <Button bg="primary">Book Now</Button>
            </td>
        </tr>
        <tr className="border-secondary">
            <td colSpan={5}>
                <div className="row" style = {{objectFit :"cover"}}>
                    {ImageList}
                </div>
            </td>
        </tr>
    </>
    )
}
export default RoomItem