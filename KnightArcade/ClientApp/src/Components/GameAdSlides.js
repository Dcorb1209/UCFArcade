import React, { Component } from 'react'
import { Jumbotron, Button, Carousel, Grid, Row, Col } from 'react-bootstrap';
import '../GameAdvert.css';

export class GameAdSlides extends Component {
  render() {
    return (
      <div className="FullPage">
        <Carousel className = "GameAdSlides">
        <Carousel.Item>
            <img width={896} height={504} alt="896x504" src={require('../slideTest.png')} />
            <Carousel.Caption>
            <h3>Game 1</h3>
            <p>Game 1 description bla bla ba</p>
            </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
            <img width={896} height={504} alt="896x504" src={require('../slideTest.png')} />
            <Carousel.Caption>
            <h3>Game 2</h3>
            <p>Game 2 description bla bla bla bla bla bla</p>
            </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
            <img width={896} height={504} alt="896x504" src={require('../slideTest.png')} />
            <Carousel.Caption>
            <h3>Game 3</h3>
            <p>Game 3 description bla bla bla... you get the point</p>
            </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
            <img width={896} height={504} alt="896x504" src={require('../slideTest.png')} />
            <Carousel.Caption>
            <h3>Game 4</h3>
            <p>Game 4 description bla bla bla... you get the point</p>
            </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
            <img width={896} height={504} alt="896x504" src={require('../slideTest.png')} />
            <Carousel.Caption>
            <h3>Game 5</h3>
            <p>Game 5 description bla bla bla... you get the point</p>
            </Carousel.Caption>
        </Carousel.Item>
        </Carousel>
      </div>
    )
  }
}

export default GameAdSlides
