import React, { Component } from 'react';
import { Modal, Button, Form, FormControl, InputGroup } from 'react-bootstrap';
import { ErrorList } from "../../../components/ErrorList";

// Services
import { UserService } from '../../../services/UserService';
import { InvitationService } from '../../../services/InvitationService';

export class SearchUserPopup extends Component {
  constructor(props) {
    super(props);
    this.state = {
      searchQuery: '',
      recordsPerPage: 5,
      page: 1,
      users: [],
      targetUser: '',
      message: '',
      searchStatus: 'init',
      inviteStatus: 'init',
      error: ''
    };
    this.userService = new UserService();
    this.invitationService = new InvitationService();
  }

  searchUsers(searchQuery) {
    const { recordPerPage, page } = this.state;
    this.setState({ loading: true });
    this.userService
      .searchUsers(searchQuery, recordPerPage, page)
      .then((data) => {
        this.setState({
          users: data ?? this.state.users,
          loading: false,
        });
      })
      .catch((error) => {
        const message = JSON.parse(error.message).message;
        this.setState({ 
          message: message,
          loading: false,
          error: error.message
        });
      });
  }

  handleSearch = () => {
    const { searchQuery, recordsPerPage, page } = this.state;
    this.setState({ 
      searchStatus: 'searching',
      error: ''
    });
    this.userService
      .searchUsers(searchQuery, recordsPerPage, page)
      .then((data) => {
        this.setState({
          users: data ?? this.state.users,
          searchStatus: 'done'
        });
        if (data && data.length > 0) {
          this.setState({ targetUser: data[0].id });
        }
      })
      .catch((error) => {
        this.setState({
          loading: false,
          error: error.message,
          searchStatus: 'init'
        });
      });
  } 

  handleInvite = () => {
    const { targetUser } = this.state;
    this.setState({ inviteStatus: 'inviting' });

    this.props.onInviteAttendee(targetUser);
    this.setState({ inviteStatus: 'done' }); 
  };

  handleSelectUser = (event) => {
    this.setState({ targetUser: event.target.value });
    console.log(this.state.targetUser);
  };

  handleClear = () => {
    this.setState({ 
      inviteStatus: 'init',
      searchStatus: 'init',
      searchQuery: ''
    }); 
  };
  
  handleClose = () => {
    this.handleClear();
    this.props.onClosePopup();
  };

  handleInputChange = (event) => {
    this.setState({ searchQuery: event.target.value });
  };

  render() {
    const { searchQuery, targetUser, users, searchStatus, inviteStatus, error } = this.state;
    const { showPopup } = this.props;

    return (
      <Modal show={showPopup} onHide={this.handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Serach users</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <InputGroup>
            {
              searchStatus === 'init'
                ? (
                  <FormControl
                    type="text"
                    placeholder="Search..."
                    value={searchQuery}
                    onChange={this.handleInputChange}
                  />
                )
                : searchStatus === 'searching' 
                  ? (
                      <>
                        <FormControl
                          type="text"
                          placeholder="Searching..."
                          value="Searching..."
                          readOnly={true}
                        />
                      </>
                    )
                  : (
                    <>
                    <Form.Select
                      value={targetUser}
                      onChange={this.handleSelectUser}
                    >
                      {
                        users.map((user, index) => (
                          <option value={user.id} key={index}>{user.lastName + ' ' + user.firstName}</option>
                        ))
                      }
                    </Form.Select>
                  </>                   
                  )
            }
            <Button className="outline-secondary" onClick={this.handleSearch}>Search</Button>
          </InputGroup>
        </Modal.Body>
        <Modal.Footer className="card-footer text-end">
          {error ? <ErrorList errors={error}/> : ''}
          {
            searchStatus === "done" 
              ? 
                <>
                  <Button variant="warning" onClick={this.handleClear}>
                    Clear
                  </Button>
                  <Button variant="primary" onClick={this.handleInvite}>
                    {
                      inviteStatus === "init" 
                        ? "Invite to appointment"
                        :  inviteStatus === "inviting"
                          ?  "Sending invitation"
                          : "Invited"
                    }
                  </Button>
                </>
              : <></>
          }
          <Button variant="secondary" onClick={this.handleClose}>Close</Button>
        </Modal.Footer>
      </Modal>
    );
  }
}

