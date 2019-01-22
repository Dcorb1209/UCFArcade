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

        <Grid>
        <Row>
        <Col xs={10} xsOffset={1} sm={6} smOffset={3}>
        <Form>
          <FormGroup>
            <ControlLabel>Title of the Game</ControlLabel>
            <FormControl
              type="text"
              placeholder="Enter the title of your game"
            />
          </FormGroup>

          <FormGroup controlId="formControlsTextarea">
            <ControlLabel>Description</ControlLabel>
            <FormControl componentClass="textarea" placeholder="Description" />
          </FormGroup>

          <FormGroup controlId="formControlsTextarea">
            <ControlLabel>Controls</ControlLabel>
            <FormControl componentClass="textarea" placeholder="Controls" />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Video (Optional)</ControlLabel>
            <FormControl
              type="text"
              placeholder="Video (Youtube Link)"
            />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Game Files (Zip)</ControlLabel>
            <FormControl
              type="file"
            />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Banner Image</ControlLabel>
            <FormControl
              type="file"
            />
          </FormGroup>

          <FormGroup>
              <Checkbox>Genre 1</Checkbox>
              <Checkbox>Genre 2</Checkbox>
              <Checkbox>Genre 3</Checkbox>
              <Checkbox>Genre 4</Checkbox>
              <Checkbox>Genre 5</Checkbox>
          </FormGroup>

          <FormGroup>
              <Button bsStyle="primary">Submit</Button>
          </FormGroup>
        </Form>
        </Col>
        </Row>
        </Grid>
      </div>
    )
  }
}

export default Submit;