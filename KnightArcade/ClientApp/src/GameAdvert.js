import React, { Component } from 'react';
import NaviBar from './Components/NavBar';
import './Games.css';
import {Panel, Grid, Row, Col} from 'react-bootstrap';

class GameAdvert extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
            <Grid fluid style={{ paddingLeft: 0, paddingRight: 0 }}>
                <Row style={{ marginLeft: 0, marginRight: 0 }}>
                    <Col md={8} mdOffset={2} style={{ paddingLeft: 0, paddingRight: 0 }}>
                        <h1>Game Name</h1>
                    </Col>
                    <Col>
                    </Col>
		    </Row>
		</Grid>
      </div>
    )
  }
}

export default GameAdvert;