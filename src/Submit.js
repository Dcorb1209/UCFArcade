import React, { Component } from 'react';
import {FormGroup, FormControl, ControlLabel, HelpBlock} from 'react-bootstrap';
import NaviBar from './Components/NavBar';
import './Submit.css';

class Submit extends Component {
  constructor(props, context) {
    super(props, context);

    this.handleChange = this.handleChange.bind(this);

    this.state = {
      value: ''
    };
  }

  getValidationState() {
    const length = this.state.value.length;
    if (length > 10) return 'success';
    else if (length > 5) return 'warning';
    else if (length > 0) return 'error';
    return null;
  }

  handleChange(e) {
    this.setState({ value: e.target.value });
  }
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <div className = 'SubmissionPage'>
        <h1>Submission</h1>
        <p>To submit your game you need to fill out the following page. Please include a one to three paragraph summary or desription of your game.</p>
        <form>
        <FormGroup
          controlId="formBasicText"
          validationState={this.getValidationState()}
        >
          <ControlLabel>Working example with validation</ControlLabel>
          <FormControl
            type="text"
            value={this.state.value}
            placeholder="Enter text"
            onChange={this.handleChange}
          />
          <FormControl.Feedback />
          <HelpBlock>Validation is based on string length.</HelpBlock>
        </FormGroup>
      </form>
        </div>
      </div>
    )
  }
}

export default Submit;