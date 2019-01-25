import React, { Component } from 'react';
import NaviBar from './Components/NavBar';
import { Button, Thumbnail, Grid, Row, Col, Image, FormGroup, FormControl, ControlLabel, ButtonGroup, Label, Panel } from 'react-bootstrap';
import './MyProfile.css';

class MyProfile extends Component {
  
  constructor(props, context) {
    super(props, context);

    this.handleEditUsername = this.handleEditUsername.bind(this);
    this.handleEditName = this.handleEditName.bind(this);
    this.handleEditMajor = this.handleEditMajor.bind(this);

    this.state = {
      usernameOpen: false,
      nameOpen: false,
      majorOpen: false
    };
  }

  handleEditUsername() {
      this.setState({ usernameOpen: !this.state.usernameOpen });
  }

  handleEditName() {
      this.setState({ nameOpen: !this.state.nameOpen });
  }

  handleEditMajor() {
      this.setState({ majorOpen: !this.state.majorOpen });
  }

  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <Grid>
          <Row>
            <Col className="my-profile__avatar-col" md={4} mdOffset={4}>
              <Image className="my-profile__avatar" src={require('./avatarTest.png')} responsive/>
            </Col>
          </Row>
          <Row>
            <Col className="my-profile__file-chooser-col" md={4} mdOffset={4}>
              <Button className="my-profile__pic-button" bsSize="small" bsStyle="primary">Change Profile Picture</Button>
            </Col>
          </Row>
          <Row>
            <Col md={8} mdOffset={2}>
              <hr className="my-profile__hr" />
            </Col>
          </Row>
          <Row>
            <Col className="my-profile__section-col" md={2} mdOffset={2}>
              <h5 className="my-profile__variable-name"><b>Username</b></h5>
            </Col>
            <Col className="my-profile__section-col" md={4}>
              <h5 className="my-profile__variable-name">DrewIsSuperKOOL</h5>
            </Col>
            <Col className="my-profile__link-col" md={2}>
              <Button bsStyle="link" bsSize="medium" onClick={this.handleEditUsername}>Edit</Button>
            </Col>
          </Row>
          <Row>
            <Col md={8} mdOffset={2}>
              <Panel className="my-profile__collapsed-panel" id="collapsible-panel-example-1" expanded={this.state.usernameOpen}>
                <Panel.Collapse>
                  <Panel.Body>
                    lkajsdlf;kjas;ldkfjas;ldkfjas;ldkfjas;ldkfjas.
                  </Panel.Body>
                </Panel.Collapse>
              </Panel>
            </Col>
          </Row>
          <Row>
            <Col className="my-profile__section-col" md={2} mdOffset={2}>
              <h5 className="my-profile__variable-name"><b>Name</b></h5>
            </Col>
            <Col className="my-profile__section-col" md={4}>
              <h5 className="my-profile__variable-name">Drew Corbeil</h5>
            </Col>
            <Col className="my-profile__link-col" md={2}>
              <Button bsStyle="link" bsSize="medium" onClick={this.handleEditName}>Edit</Button>
            </Col>
          </Row>
          <Row>
            <Col md={8} mdOffset={2}>
              <Panel className="my-profile__collapsed-panel" id="collapsible-panel-example-1" expanded={this.state.nameOpen}>
                <Panel.Collapse>
                  <Panel.Body>
                    lkajsdlf;kjas;ldkfjas;ldkfjas;ldkfjas;ldkfjas.
                  </Panel.Body>
                </Panel.Collapse>
              </Panel>
            </Col>
          </Row>
          <Row>
            <Col className="my-profile__section-col" md={2} mdOffset={2}>
              <h5 className="my-profile__variable-name"><b>Major</b></h5>
            </Col>
            <Col className="my-profile__section-col" md={4}>
              <h5 className="my-profile__variable-name">Computer Science</h5>
            </Col>
            <Col className="my-profile__link-col" md={2}>
              <Button bsStyle="link" bsSize="medium" onClick={this.handleEditMajor}>Edit</Button>
            </Col>
          </Row>
          <Row>
            <Col md={8} mdOffset={2}>
              <Panel className="my-profile__collapsed-panel" id="collapsible-panel-example-1" expanded={this.state.majorOpen}>
                <Panel.Collapse>
                  <Panel.Body>
                    lkajsdlf;kjas;ldkfjas;ldkfjas;ldkfjas;ldkfjas.
                  </Panel.Body>
                </Panel.Collapse>
              </Panel>
            </Col>
          </Row>
          <Row>
            <Col md={8} mdOffset={2}>
              <hr className="my-profile__hr" />
            </Col>
          </Row>
        </Grid>
      </div>
    )
  }
}

export default MyProfile;