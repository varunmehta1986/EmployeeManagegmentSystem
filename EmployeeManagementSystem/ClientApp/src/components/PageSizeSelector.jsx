import React, { Component } from "react";
class PageSizeSelector extends Component {
  state = {};
  render() {
    return (
      <div className="form-group row">
        <label htmlFor="selectPageSize">Page Size</label>
        <select
          className="form-control col-md-2"
          name="selectPageSize"
          defaultValue="5"
          onChange={this.props.onPageSizeChange}
        >
          <option>5</option>
          <option>10</option>
          <option>15</option>
          <option>20</option>
        </select>
      </div>
    );
  }
}

export default PageSizeSelector;
