import React, { Component } from 'react';
import NaviBar from './Components/NavBar';
import './Games.css';

class Games extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <h1 className = 'text'>Games</h1>
      </div>
    )
  }
}

export default Games;