import React, { Component } from 'react';
import NaviBar from './Components/NavBar';
import './GameAdvert.css';
import GameAdSlides from './Components/GameAdSlides';
import {Panel, Grid, Row, Col, Glyphicon, Button} from 'react-bootstrap';

class GameAdvert extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <div className = 'GameAdDiv'>
            <Grid fluid style={{ paddingLeft: 0, paddingRight: 0 }}>
                <Row style={{ marginLeft: 0, marginRight: 0 }}>
                    <Col md={8} mdOffset={2} style={{ paddingLeft: 0, paddingRight: 0 }}>
                      <h1>Game Name</h1>
                    </Col>
                </Row>
                <Row style={{ marginLeft: 0, marginRight: 0 }}>
                <Panel className = 'GameAdPanel'>
                <Panel.Body className = 'GameAdPanelBody'>
                  <Col md={6} mdOffset={0} style={{ paddingLeft: 0, paddingRight: 0 }}>
                    <GameAdSlides/>
                  </Col>
                  <Col md={3} mdOffset={3} style={{ paddingLeft: 0, paddingRight: 0 }}>
                    <div>
                      <h3>Creator</h3>
                      <p>Terry Crews</p>
                      <h3>Date Published</h3>
                      <p>2019-02-10 12:29:00</p>
                      <h3>Genres</h3>
                      <p className = 'GameAdGenreList'>Action, Adventure</p>
                      <br></br>
                      <h4>Available on arcade machines:</h4>
                      <Glyphicon glyph='ok' className = 'Check'/> 
                      <br></br>
                      <a className ='GameAdDownload' href ="https://www.youtube.com/watch?v=dQw4w9WgXcQ" target = "_blank">
                        <button href = "https://www.youtube.com/watch?v=dQw4w9WgXcQ" download = "Rick">Download</button>
                      </a>
                    </div>
                  </Col>
                </Panel.Body>
                </Panel>
                </Row>
                <Row style={{ marginLeft: 0, marginRight: 0 }}>
                  <Col md={4} mdOffset={2} style={{ paddingLeft: 0, paddingRight: 0 }}>
                    <h3>About the game</h3>
                    <p>AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAA AAAAAAA AAAAAAAAAA AAAAAAA AAAAAAA AAAAAAAAAAAAa AAAAAAAAAAAAA AAAAAAAAAAA AAAAAAAAA AAAAAAAA AAAAAAAAAAAAAA  AAAAAAAAAAA AaAAAAAAAAAAAA AAAAAAAAAA AA AAAAAAAAAAAA AAAAA AAAAAAAAAAAA AA AAAAAAAAAAAAa AAAAAAAAAAAAAA AAAAAAAAAA  AAAAAAAAAA AAAAAAA AAAAA AAAAAAAAA AAA AAAAAAAAAa</p>
                  </Col>
                  <Col md={2} mdOffset={1} style={{ paddingLeft: 0, paddingRight: 0 }}>
                  <h3>Controls</h3>
                  <p>fddgffhgfghfgf\nghg hghgfgfhgfhgfghfhgf hgfghfhfhgfghfghfhg gf hgf hgf hgfhgf hgf hgf hgfhgf hggfhg fghf hgf hgfgh hgfhgf hgf hgf hgf hgf hgfhg hgfhgf hgfhgfhgf hgf hfghfhgf ghf hg fh</p>
                  </Col>
                </Row>
		          </Grid>
        </div>
      </div>
    )
  }
}

export default GameAdvert;