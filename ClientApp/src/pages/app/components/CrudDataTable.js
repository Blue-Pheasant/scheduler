import React, { Component } from 'react';
import { Table, Pagination, Dropdown, Button } from 'react-bootstrap';
import { ActionDropdown } from "./ActionDropdown";
import { Color } from './Color';
import { checkColor } from "./Calendar/utils";
import '../static/css/data-table.css';
import { Action } from './Action';

export class CrudDataTable extends Component {
  constructor(props) {
    super(props);

    this.state = {
      entriesPerPage: 5,
      activePage: 1
    };

    this.handleSelectPage = this.handleSelectPage.bind(this);
    this.handleSelectEntries = this.handleSelectEntries.bind(this);
  }

  handleSelectPage(eventKey) {
    this.setState({
      activePage: eventKey
    });
  }

  handleSelectEntries(eventKey) {
    this.setState({
      entriesPerPage: eventKey,
      activePage: 1
    });
  }

  render() {
    const { entries, color, onDelete, onUpdate, onView, onAnother } = this.props;

    if (entries.length === 0) {
      return <p>No data available.</p>;
    }

    const { entriesPerPage, activePage } = this.state;
    const pageCount = Math.ceil(entries.length / entriesPerPage);

    const headers = Object.keys(entries[0]);
    const startIndex = (activePage - 1) * entriesPerPage;
    const endIndex = startIndex + entriesPerPage;
    const currentEntries = entries.slice(startIndex, endIndex);
    
    return (
      <>
        <div className="table-responsive">
          <Table bordered hover >
            <thead>
              <tr>
                {headers.map((header, index) => (
                  <th key={index}>{header}</th>
                ))}
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
             {currentEntries.map((row, index) => (
                <tr key={index}>
                  {headers.map((header) => (
                    color 
                    ? <td key={header}> {checkColor(row[header]) ? <Color value={row[header]}/> : row[header]}  </td>
                    : <td key={header}>{row[header]}</td>
                  ))}
                  <td className="text-end">
                  { onView ? 
                    <Action id={row['id']} action="view" onView={onView}/> 
                    : null
                  }
                  { onUpdate ? 
                    <Action id={row['id']} action="update" onUpdate={onUpdate}/> 
                    : null
                  }
                  { onDelete ? 
                    <Action id={row['id']} action="delete" onDelete={onDelete}/> 
                    : null
                  }
                  { onAnother ? 
                    <Action id={row['id']} action="another" onAnother={onAnother}/>
                    : null
                  }
                </td>
              </tr>
              ))}
            </tbody>
          </Table>
        </div>

        <div className="d-flex justify-content-between align-items-center">
          <Dropdown>
            <Dropdown.Toggle variant="light" id="dropdown-entries">
              Entries per page: {entriesPerPage}
            </Dropdown.Toggle>
            <Dropdown.Menu>
              {[10, 25, 50].map((entries) => (
                <Dropdown.Item
                  key={entries}
                  active={entries === entriesPerPage}
                  onClick={() => this.handleSelectEntries(entries)}
                >
                  {entries}
                </Dropdown.Item>
              ))}
            </Dropdown.Menu>
          </Dropdown>

          <Pagination>
            {[...Array(pageCount)].map((_, index) => (
              <Pagination.Item
                key={index}
                active={index + 1 === activePage}
                onClick={() => this.handleSelectPage(index + 1)}
              >
                {index + 1}
              </Pagination.Item>
            ))}
          </Pagination>
        </div>
      </>
    );
  }
}