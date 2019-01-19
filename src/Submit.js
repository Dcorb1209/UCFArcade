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
    if (length >= 1) return 'success';

    return null;
  }
  getValidationStateDesc() {
    const length = this.state.value.length;
    if (length >= 100) return 'success';
    else if (length >= 1) return 'warning';

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
        
        {/*Game Title Form*/}
        <form>
        <FormGroup
          controlId="gameTitleForm"
          validationState={this.getValidationState()}
        >
          <ControlLabel>Title of the game</ControlLabel>
          <FormControl
            type="text"
            value={this.state.value}
            placeholder="Enter the title of your game"
            onChange={this.handleChange}
          />
          <FormControl.Feedback />
        </FormGroup>
      </form>

      {/*Game Description Form*/}
      <form>
        <FormGroup
          controlId="gameDescriptionForm"
          validationState={this.getValidationStateDesc()}
        >
          <ControlLabel>Game Description</ControlLabel>
          <FormControl
            type="text"
            value={this.state.value}
            placeholder="Enter the description of your game"
            onChange={this.handleChange}
          />
          <FormControl.Feedback />
        </FormGroup>
      </form>
        </div>
      </div>
    )
  }
}

export default Submit;