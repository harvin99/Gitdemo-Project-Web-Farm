import React, { useState, useEffect } from 'react';
const BookRoom = ({ Id, Name, Price }) => {
    const initValue = {
        CheckinDay: "",
        NumberOfDays: 0,
        FullName: "",
        Email: "",
        Telephone: ""
    }

    const [formAttr, setFormAttr] = useState(initValue)

    const Total = Price * formAttr.NumberOfDays;
    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        if (name === "NumberOfDays") {
            setFormAttr({
                ...formAttr,
                NumberOfDays: isNaN(value) ? formAttr.NumberOfDays : value
            })
        } else {
            setFormAttr({
                ...formAttr,
                [e.target.name]: e.target.value
            })
        }



    }

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(formAttr)
    }
    return (
        <div className="container-fluid bg-light mt-4 p-5 rounded">
            <h1 className="text-warning">
                <i className="fa fa-bed mb-2" />
                Booking information
        </h1>
            <h3 className="mt-4">Room name: {Name}</h3>
            <form className="mt-4" onSubmit={handleSubmit}>
                <div className="row">
                    <div className="form-group col-lg-3 col-sm-12">
                        <label>Checkin day</label>
                        <input type="date" name="CheckinDay" value={formAttr.CheckinDay} onChange={handleChange} className="form-control" placeholder={new Date().toJSON().slice(0, 10)} />
                    </div>
                    <div className="form-group col-lg-3 col-sm-12">
                        <label>Price per day</label>
                        <input name="Price" value={Price}
                            className="form-control"
                            type="text"

                            readOnly
                        />
                    </div>
                    <div className="form-group col-lg-3 col-sm-12">
                        <label>Number of days</label>
                        <input type="number" min="0" name="NumberOfDays" value={formAttr.NumberOfDays} onChange={handleChange} className="form-control" />
                    </div>
                    <div className="form-group col-lg-3 col-sm-12">
                        <label>Total</label>
                        <input
                            className="form-control"
                            type="text"
                            value={Total}
                            readOnly
                        />
                    </div>
                </div>
                <h4>Contact information</h4>
                <div className="row">
                    <div className="form-group col-lg-3 col-sm-12">
                        <label>Fullname</label>
                        <input name="FullName" value={formAttr.FullName} onChange={handleChange} className="form-control" />
                    </div>
                    <div className="form-group col-lg-3 col-sm-12">
                        <label>Email</label>
                        <input type="email" name="Email" value={formAttr.Email} onChange={handleChange} className="form-control" />
                    </div>
                    <div className="form-group col-lg-3 col-sm-12">
                        <label>Telephone(Optional)</label>
                        <input type="tel" pattern="[0-9]{10,11}" name="Telephone" value={formAttr.Telephone} onChange={handleChange} className="form-control" />
                    </div>
                </div>
                <div className="text-center mt-4">
                    <button
                        className="btn btn-warning rounded"
                        id="submit"
                        type="submit"
                    >
                        Check out with
              <i className="fa fa-cc-paypal" />
                    </button>
                </div>
            </form>
        </div>
    )
}
export default BookRoom