import React, { Component } from 'react';
import {FormGroup, FormControl, ControlLabel, HelpBlock, Form, Button, Col, Checkbox, Panel, Grid, Row} from 'react-bootstrap';
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
        <div className="Header">
        <h1>Submit a Game</h1>
        </div>
    
    <Form horizontal>           
      {/*Game Title Form*/}
      <FormGroup
        controlId="gameTitleForm"
        validationState={this.getValidationState()}
      >
        <Col componentClass={ControlLabel} md={4}>Title of the game</Col>
        <Col md={4}>
         <FormControl
            type="text"
            value={this.state.value}
              placeholder="Enter the title of your game"
           onChange={this.handleChange}
          />
          <FormControl.Feedback />
        </Col>
        </FormGroup>
  <FormGroup controlId="formDescription">
    <Col componentClass={ControlLabel} md={4}>
      Description
    </Col>
    <Col md={4}>
      <FormControl 
        componentClass="textArea" 
        type="text" 
        placeholder="Description" />
    </Col>
  </FormGroup>

  <FormGroup controlId="formControls">
    <Col componentClass={ControlLabel} md={4}>
      Controls
    </Col>
    <Col md={4}>
      <FormControl 
        componentClass="textArea" 
        type="text" 
        placeholder="Controls" />
    </Col>
  </FormGroup>

  <FormGroup controlId="formVideo">
    <Col componentClass={ControlLabel} md={4}>
      Video (Optional)
    </Col>
    <Col md={4}>
      <FormControl  
        type="text" 
        placeholder="Video (Youtube Link)" />
    </Col>
  </FormGroup>

  <FormGroup controlId="formGameFile">
    <Col componentClass={ControlLabel} md={4}>
      Game Files (Zip)
    </Col>
    <Col md={4}>
      <FormControl  
        type="file" 
        placeholder="Choose File" />
    </Col>
  </FormGroup>


  <FormGroup controlId="formGameScreenShot">
    <Col componentClass={ControlLabel} md={4}>
      Banner Screenshot
    </Col>
    <Col md={4}>
      <FormControl  
        type="file" 
        placeholder="Choose File" />
    </Col>
  </FormGroup>




  <FormGroup>
    <Col md={4} mdOffset={4}>
      <Checkbox>Genre 1</Checkbox>
      <Checkbox>Genre 2</Checkbox>
      <Checkbox>Genre 3</Checkbox>
      <Checkbox>Genre 4</Checkbox>
      <Checkbox>Genre 5</Checkbox>
    </Col>
  </FormGroup>

  <FormGroup>
    <Col md={4} mdOffset={4}>
      <Button bsStyle="primary">Submit</Button>
    </Col>
  </FormGroup>
</Form>
      </div>
    )
  }
}

export default Submit;