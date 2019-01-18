import React, { Component } from 'react';
import NaviBar from './Components/NavBar';
import { Button, Thumbnail, Grid, Row, Col } from 'react-bootstrap';

class MyProfile extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <Grid>
          <Row>
            <Col xs={4} md={3}>
              <Thumbnail src={require('./avatarTest.png')}>
                  <Button bsStyle="primary">Change Avatar</Button>
              </Thumbnail>
            </Col>
          </Row>
        </Grid>
      </div>
    )
  }
}

export default MyProfile;