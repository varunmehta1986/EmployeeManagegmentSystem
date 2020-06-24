import React, { Component } from "react";
import Pagination from "react-js-pagination";
import PageSizeSelector from "./PageSizeSelector";

class EmployeeList extends Component {
  state = {
    employees: [],
    loading: true,
    currentPage: 1,
    employeesPerPage: 5,
    totalRecords: 0,
  };
  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading..</em>
      </p>
    ) : (
      this.renderEmployeeTable(this.state.employees)
    );
    return <div>{contents}</div>;
  }

  async componentDidMount() {
    this.getEmployees(this.state.currentPage);
  }

  handlePageChange(pageNumber) {
    this.setState({ currentPage: pageNumber });
    this.getEmployees(pageNumber);
  }
  renderPageLinks() {
    return (
      <div>
        <Pagination
          itemClass="page-item"
          linkClass="page-link"
          activePage={this.state.currentPage}
          itemsCountPerPage={this.state.employeesPerPage}
          totalItemsCount={this.state.totalRecords}
          pageRangeDisplayed={5}
          onChange={this.handlePageChange.bind(this)}
        />
      </div>
    );
  }

  async getEmployees(pageNumber) {
    const response = await fetch(
      "employee?currentPage=" +
        pageNumber +
        "&pageSize=" +
        this.state.employeesPerPage
    );

    const data = await response.json();
    this.setState({
      employees: data.employees,
      loading: false,
      totalRecords: data.totalRecords,
    });
  }
  handleDeleteEmployee = (employeeId) => {
    console.log("delete employee id " + employeeId);
    fetch("employee?employeeId=" + employeeId, {
      method: "DELETE",
      headers: { "Content-type": "application/json" },
    }).then((response) => {
      if (response.ok) {
        this.setState({ message: "Employee Deleted!" });
        this.getEmployees(this.state.currentPage);
      } else {
        this.setState({
          message: "Error deleting Employee",
        });
      }
    });
  };
  renderEmployeeTable(employees) {
    const pageLinks = this.renderPageLinks();
    return (
      <div>
        <PageSizeSelector
          onPageSizeChange={this.handlePageSizeChange.bind(this)}
        ></PageSizeSelector>
        <table className="table table-striped" aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Employee Number</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Date Joined</th>
              <th>Extension</th>
              <th>Role</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((emp) => (
              <tr key={emp.employeeId}>
                <td>{emp.employeeNumber}</td>
                <td>{emp.firstName}</td>
                <td>{emp.lastName}</td>
                <td>{emp.dateJoined}</td>
                <td>{emp.extension}</td>
                <td>{emp.role}</td>
                <td>
                  <button
                    type="button"
                    className="btn btn-danger btn-sm"
                    onClick={() => this.handleDeleteEmployee(emp.employeeId)}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        {pageLinks}
      </div>
    );
  }
  handlePageSizeChange(event) {
    this.setState(
      {
        employeesPerPage: parseInt(event.target.value),
        currentPage: 1,
      },
      () => this.getEmployees(this.state.currentPage)
    );
  }
}

export default EmployeeList;
