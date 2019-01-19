import React, { Component } from 'react';
import {FormGroup, FormControl, ControlLabel, HelpBlock, Form, Button, Col, Checkbox} from 'react-bootstrap';
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
        <form id = 'gameTitle'>
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
      <Form horizontal>
  <FormGroup controlId="formDescription">
    <Col componentClass={ControlLabel} sm={2}>
      Description
    </Col>
    <Col sm={10}>
      <FormControl type="text" placeholder="Description" />
    </Col>
  </FormGroup>

  <FormGroup controlId="formControls">
    <Col componentClass={ControlLabel} sm={2}>
      Controls
    </Col>
    <Col sm={10}>
      <FormControl type="text" placeholder="Controls" />
    </Col>
  </FormGroup>

  <FormGroup>
    <Col smOffset={2} sm={10}>
      <Checkbox>Genre 1</Checkbox>
      <Checkbox>Genre 2</Checkbox>
      <Checkbox>Genre 3</Checkbox>
      <Checkbox>Genre 4</Checkbox>
      <Checkbox>Genre 5</Checkbox>
    </Col>
  </FormGroup>

  <FormGroup>
    <Col smOffset={2} sm={10}>
      <Button type="submit">Submit</Button>
    </Col>
  </FormGroup>
</Form>;

        </div>
      </div>
    )
  }
}

export default Submit;