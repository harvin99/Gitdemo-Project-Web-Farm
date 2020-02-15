import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import axios from "axios";
export default function withAuth(ComponentToProtect) {
  return class extends Component {
    constructor() {
      super();
      this.state = {
        loading: true,
        redirect: false
      };
    }
    componentDidMount() {
      const authAccount = async () => {
        try {
          const res = await axios.get("http://localhost:8080/api/account/auth",{
              headers:{
                  token: localStorage.get('token')
              }
          });
          console.log(res)
          if (res.data.status === 200) {
              console.log(res.data.status)
            this.setState({ loading: false });
          } else {
            const error = new Error(res.error);
            throw error;
          }
        } catch (error) {
          this.setState({ loading: false, redirect: true });
        }
      };
      authAccount()
    }
    render() {
      const { loading, redirect } = this.state;
      if (loading) {
        return (
            <div>loading.....</div>
        )
      }
      if (redirect) {
        //return <Redirect to="/login" />;
      }
      return (
        <React.Fragment>
          <ComponentToProtect {...this.props} />
        </React.Fragment>
      );
    }
  };
}
