import React, { Component } from "react";

export class ActionDropdown extends Component {

  render () {
    return (
      <span className="dropdown">
        <button
            className="btn dropdown-toggle align-text-top"
            data-bs-boundary="viewport"
            data-bs-toggle="dropdown"
        >
          Actions
        </button>
        <div className="dropdown-menu dropdown-menu-end">
            {
              this.props.actions.map((action, index) => {
                return (<a className="dropdown-item" key={index} href={action.href}>{action.name}</a>)
              })
            }
        </div>
      </span>
    )
  }
}