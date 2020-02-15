import React from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  Redirect,
  useHistory,
  useLocation
} from "react-router-dom";
import Login from "./components/Login";
import AdminPage from "./components/AdminPanel";
const PrivateRoute = ({ children, ...rest }) => {

    
  return (
    <Route
      {...rest}
      render={({ location }) =>
        localStorage.getItem('token') ? (
          children
        ) : (
          <Redirect
            to={{
              pathname: "/login",
              state: { from: location }
            }}
          />
        )
      }
    />
  );
};
const RouterContainer = () => {
  return (
    <Router>
      <Switch>
        <Route path="/login">
          <Login />
        </Route>
        <PrivateRoute path="/adminpage">
          <AdminPage />
        </PrivateRoute>
      </Switch>
    </Router>
  );
};
export default RouterContainer;
