import React, { Component } from 'react';
import { Navbar, Nav, NavItem, NavDropdown, MenuItem, Modal, Button, FormGroup, FormControl, ControlLabel} from 'react-bootstrap';
import './NavBar.css';
import { BrowserRouter, Route } from "react-router-dom";

export default class NaviBar extends Component {
	constructor(props) {
		super(props);

		this.handleLoginShow = this.handleLoginShow.bind(this);
    	this.handleLoginClose = this.handleLoginClose.bind(this);
    	this.handleSignupShow = this.handleSignupShow.bind(this);
    	this.handleSignupClose = this.handleSignupClose.bind(this);

	    this.state = {
	      loginShow: false,
	      signupShow: false
	    };
	}

	handleLoginClose() {
    	this.setState({ loginShow: false });
  	}

  	handleLoginShow() {
    	this.setState({ loginShow: true });
  	}

  	handleSignupClose() {
    	this.setState({ signupShow: false });
  	}

  	handleSignupShow() {
    	this.setState({ signupShow: true });
  	}

	render(props) {
		return (
			
			<Navbar inverse collapseOnSelect>
			  <Navbar.Header>
			    <Navbar.Brand>
			      <a href="/">Arcade GRASS</a>
			    </Navbar.Brand>
			    <Navbar.Toggle />
			  </Navbar.Header>
			  <Navbar.Collapse>
			    <Nav>
			      <NavItem eventKey={1} href="#">
			        Games
			      </NavItem>
			      <NavItem eventKey={2} href="#">
			        About
			      </NavItem>
			      <NavItem eventKey={3} href="#">
			        Submit
			      </NavItem>
			      <NavItem href="MyProfile">
			        My Profile
			      </NavItem>
			      {/*<NavDropdown eventKey={3} title="Dropdown" id="basic-nav-dropdown">
			        <MenuItem eventKey={3.1}>Action</MenuItem>
			        <MenuItem eventKey={3.2}>Another action</MenuItem>
			        <MenuItem eventKey={3.3}>Something else here</MenuItem>
			        <MenuItem divider />
			        <MenuItem eventKey={3.3}>Separated link</MenuItem>
			      </NavDropdown>*/}
			    </Nav>
			    <Nav pullRight>
			      <NavItem onClick={this.handleSignupShow} eventKey={1} href="#">
			        Sign Up
			      </NavItem>

			      <Modal className='NavBar-modal' bsSize="small" show={this.state.signupShow} onHide={this.handleSignupClose}>
			          <Modal.Header closeButton>
			            <Modal.Title>Sign Up</Modal.Title>
			          </Modal.Header>
			          <Modal.Body>
			            <form>
			            	<FormGroup>
						      <ControlLabel>First Name</ControlLabel>
						      <FormControl
						      	type="text"
						      />
						    </FormGroup>
						    <FormGroup>
						      <ControlLabel>Last Name</ControlLabel>
						      <FormControl
						      	type="text"
						      />
						    </FormGroup>
						    <FormGroup>
						      <ControlLabel>Display Name</ControlLabel>
						      <FormControl
						      	type="text"
						      />
						    </FormGroup>
						    <FormGroup>
						      <ControlLabel>Email (Login)</ControlLabel>
						      <FormControl
						      	type="text"
						      />
						    </FormGroup>
						    <FormGroup>
						      <ControlLabel>Password</ControlLabel>
						      <FormControl
						      	type="password"
						      />
						    </FormGroup>
						    <FormGroup>
						      <ControlLabel>Confirm Password</ControlLabel>
						      <FormControl
						      	type="password"
						      />
						    </FormGroup>
						    <FormGroup>
						      <ControlLabel>Major</ControlLabel>
						      <FormControl
						      	type="text"
						      />
						    </FormGroup>
			            </form>
			          </Modal.Body>
			          <Modal.Footer>
			            <Button onClick={this.handleSignupClose}>Submit</Button>
			          </Modal.Footer>
			       </Modal>

			      <NavItem onClick={this.handleLoginShow} eventKey={2} href="#">
			        Log In
			      </NavItem>

			      <Modal className='NavBar-modal' bsSize="small" show={this.state.loginShow} onHide={this.handleLoginClose}>
			          <Modal.Header closeButton>
			            <Modal.Title>Log In</Modal.Title>
			          </Modal.Header>
			          <Modal.Body>
			            <form>
				            <FormGroup>
						      <ControlLabel>Email address</ControlLabel>
						      <FormControl
						      	type="text"
					            placeholder="Enter email"
						      />
						    </FormGroup>
						    <FormGroup>
						      <ControlLabel>Password</ControlLabel>
						      <FormControl
						      	type="password"
						      />
						    </FormGroup>
					    </form>
			          </Modal.Body>
			          <Modal.Footer>
			            <Button onClick={this.handleLoginClose}>Submit</Button>
			          </Modal.Footer>
			       </Modal>

			    </Nav>
			  </Navbar.Collapse>
			</Navbar>

		);
	}
}