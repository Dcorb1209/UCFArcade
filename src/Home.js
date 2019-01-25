import React, { Component } from 'react';
import './App.css';
import NaviBar from './Components/NavBar';
import { Jumbotron, Button, Carousel, Grid, Row, Col } from 'react-bootstrap';
import GameSlides from './Components/GameSlides';

class Home extends Component {
  render() {
    return (
      <div className="App">
        <NaviBar/>
        <Jumbotron className ="Jumbo">
          <h1 className = "text"> Knights Arcade</h1>
          <p className = "text">
            Play / Share / Showcase
          </p>
          <p>
            <Button bsStyle="primary">Find An Arcade Machine</Button>
          </p>
        </Jumbotron>

        <GameSlides/>
      </div>
    )
  }
}

export default Home;