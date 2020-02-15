import React, { useState } from 'react';
import { Container, Row, Col, Form, Button } from 'react-bootstrap';
const ApplicationForm = (props) => {
    const initFormAttr = {
        Jobname: "",
        Name: "",
        Email: "",
        Startwork: ""

    }
    const [formAttr, setFormAttr] = useState(initFormAttr);
    const handleChange = (e) => {
        setFormAttr({
            ...formAttr,
            [e.target.name]: e.target.value
        })
    }
    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(formAttr)
    }
    return (
        <div className = "m-3">
        <Container fluid={true} className="p-5" style={{ backgroundColor: '#E9ECEF' }}>
            <Row>
                <h1 className="text-warning">
                    <i className="fa fa-briefcase m-3"></i>Application from
          </h1>
            </Row>
            <Row>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">Job name:</label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">What is your name?</label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>

                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">Email:</label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
            </Row>
            <Row>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">
                            Date avaliable to start work:
              </label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">
                            You need 2nd year visa?
              </label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">Nationality:</label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
            </Row>
            <Row>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">
                            How long can your stay?
              </label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">Phone number:</label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">
                            Do you have vehicle?
              </label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
            </Row>
            <Row>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">
                            How many peple are your applying for?
              </label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
                <Col md={4} sm={12}>
                    <Form.Group>
                        <label htmlFor="formGroupExampleInput">
                            A brief description of your experience:
              </label>
                        <input
                            type="text"
                            className="form-control"
                            id="formGroupExampleInput"
                            placeholder="Example input"
                        />
                    </Form.Group>
                </Col>
                <Col md={4} sm={12} />
            </Row>
            <Row>
                <Col className="text-center">
                    {" "}
                    <Button variant="primary">Submit</Button>
                </Col>
            </Row>
        </Container>
        </div>
    )
}
export default ApplicationForm