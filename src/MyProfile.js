import React, { Component } from 'react';
import NaviBar from './Components/NavBar';
import { Button, Thumbnail, Grid, Row, Col, Image, Well } from 'react-bootstrap';

class MyProfile extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <Grid>
          <Row>
            <Col xs={6} sm={3} md={2}>
              <Thumbnail src={require('./avatarTest.png')}>
                  <Button bsStyle="primary" bsSize='xsmall'>Change Avatar</Button>
              </Thumbnail>
            </Col>
          </Row>
          <Row>
            <Col md={3}>
              <h3>Username:</h3>
            </Col>
          </Row>
          <Row>
            <Col md={3}>
              <h3>Major:</h3>
            </Col>
          </Row>
        </Grid>
      </div>
    )
  }
}

export default MyProfile;