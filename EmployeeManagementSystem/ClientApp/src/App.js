import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";

import "./custom.css";
import EmployeeList from "./components/EmployeeList";
import AddEmployee from "./components/AddEmployee";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/allemployees" component={EmployeeList} />
        <Route path="/addemployee" component={AddEmployee} />
      </Layout>
    );
  }
}
