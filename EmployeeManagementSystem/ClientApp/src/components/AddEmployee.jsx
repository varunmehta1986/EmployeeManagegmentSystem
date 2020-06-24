import React, { Component } from "react";
// import DatePicker from "react-bootstrap-date-picker";
class AddEmployee extends Component {
  state = {};

  constructor(props) {
    super(props);
    this.state = {
      employeeNumber: 0,
      firstName: null,
      lastName: null,
      dateJoined: new Date(),
      extension: null,
      roleId: null,
      roles: [],
      message: "",
      loading: true,
    };
  }
  async componentDidMount() {
    this.getRoles();
  }
  async getRoles() {
    const response = await fetch("role");
    const data = await response.json();
    this.setState({
      roles: data,
      loading: false,
    });
  }
  handleInputChange = (event) => {
    event.preventDefault();
    this.setState({
      [event.target.name]:
        event.target.type === "number" || event.target.name === "roleId"
          ? parseInt(event.target.value)
          : event.target.value,
    });
  };

  handleAddUserClick = (event) => {
    event.preventDefault();
    const data = this.state;
    fetch("employee", {
      method: "POST",
      headers: { "Content-type": "application/json" },
      body: JSON.stringify(data),
    }).then((response) => {
      if (response.ok) {
        this.setState({ message: "Employee Added!" });
      } else {
        this.setState({
          message: "Error adding Employee",
        });
      }
    });
  };
  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading..</em>
      </p>
    ) : (
      this.renderAddUserForm(this.state.roles)
    );
    return <div>{contents}</div>;
  }
  renderAddUserForm(roles) {
    return (
      <div>
        <form onSubmit={this.handleAddUserClick}>
          <div className="form-group">
            <label htmlFor="employeeNumber">Employee Number</label>
            <input
              type="number"
              name="employeeNumber"
              className="form-control col-md-6"
              onChange={this.handleInputChange}
            />
          </div>
          <div className="form-group">
            <label htmlFor="firstName">First Name</label>
            <input
              type="text"
              name="firstName"
              className="form-control col-md-6"
              onChange={this.handleInputChange}
            />
          </div>
          <div className="form-group">
            <label htmlFor="lastName">Last Name</label>
            <input
              type="text"
              name="lastName"
              className="form-control col-md-6"
              onChange={this.handleInputChange}
            />
          </div>
          {/* <div className="form-group">
            <label htmlFor="dateJoined">Date Joined</label>
            <DatePicker
              id="example-datepicker"
              name="dateJoined"
              onChange={this.handleInputChange}
            />
            <input
              type="text"
              name="dateJoined2"
              className="form-control col-md-6"
              onChange={this.handleInputChange}
            />
          </div> */}
          <div className="form-group">
            <label htmlFor="extension">Extension</label>
            <input
              type="number"
              name="extension"
              className="form-control col-md-6"
              onChange={this.handleInputChange}
            />
          </div>
          <div className="form-group">
            <label htmlFor="selectRole">Role</label>
            <select
              className="form-control col-md-6"
              id="selectRole"
              name="roleId"
              onChange={this.handleInputChange}
            >
              <option value="-1">--Please select a role--</option>
              {roles.map((role) => (
                <option key={role.roleID} value={role.roleID}>
                  {role.roleName}
                </option>
              ))}
            </select>
          </div>
          <button className="btn btn-primary mb-2">Add User</button>
          <p>{this.state.message}</p>
        </form>
      </div>
    );
  }
}

export default AddEmployee;
