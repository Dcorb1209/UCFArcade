import React, { Component } from 'react';
import './App.css';
import NaviBar from './Components/NavBar';
import { Jumbotron, Button, Carousel, Grid, Row, Col } from 'react-bootstrap';

class Home extends Component {
  render() {
    return (
      <div className="App">
        <NaviBar/>
        <Jumbotron>
          <h1>Knights Arcade</h1>
          <p>
            We need a new name
          </p>
          <p>
            <Button bsStyle="primary">Button</Button>
          </p>
        </Jumbotron>
        <Grid>
        <Row>
        <Col md={8} mdOffset={2}>
        <Carousel>
          <Carousel.Item>
            <img width={900} height={500} alt="900x500" src={require('./slideTest.png')} />
            <Carousel.Caption>
              <h3>Game 1</h3>
              <p>Game 1 description bla bla ba</p>
            </Carousel.Caption>
          </Carousel.Item>
          <Carousel.Item>
            <img width={900} height={500} alt="900x500" src={require('./slideTest.png')} />
            <Carousel.Caption>
              <h3>Game 2</h3>
              <p>Game 2 description bla bla bla bla bla bla</p>
            </Carousel.Caption>
          </Carousel.Item>
          <Carousel.Item>
            <img width={900} height={500} alt="900x500" src={require('./slideTest.png')} />
            <Carousel.Caption>
              <h3>Game 3</h3>
              <p>Game 3 description bla bla bla... you get the point</p>
            </Carousel.Caption>
          </Carousel.Item>
        </Carousel>
        </Col>
        </Row>
        </Grid>
      </div>
    )
  }
}

export default Home;