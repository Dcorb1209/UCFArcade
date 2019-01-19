import React, { Component } from 'react';
import NaviBar from './Components/NavBar';
import './Submit.css';

class Submit extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <div className = 'SubmissionPage'>
        <h1>Submit</h1>
        </div>
      </div>
    )
  }
}

export default Submit;