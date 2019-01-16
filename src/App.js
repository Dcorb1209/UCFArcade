import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import NaviBar from './Components/NavBar';
import { Jumbotron, Button } from 'react-bootstrap';

class App extends Component {
  render() {
    return (
      <div className="App">
        <NaviBar/>
        <Jumbotron>
          <h1>Welcome to Arcade GRASS!</h1>
          <p>
            Test
          </p>
          <p>
            <Button bsStyle="primary">Button</Button>
          </p>
        </Jumbotron>
      </div>
    )
  }
}

export default App;
