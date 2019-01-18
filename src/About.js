import React, { Component } from 'react';
import NaviBar from './Components/NavBar';

class About extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <h1>About</h1>
      </div>
    )
  }
}

export default About;