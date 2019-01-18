import React, { Component } from 'react';
import NaviBar from './Components/NavBar';

class Games extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <h1>Games</h1>
      </div>
    )
  }
}

export default Games;