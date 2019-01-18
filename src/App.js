import React, { Component } from 'react';
import './App.css';
import NaviBar from './Components/NavBar';
import { Jumbotron, Button } from 'react-bootstrap';
import { BrowserRouter, Route, Switch } from "react-router-dom";
import Home from './Home';
import MyProfile from './MyProfile';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Switch>
          <Route path="/" component={Home} exact/>
          <Route path="/MyProfile" component={MyProfile} exact/>
        </Switch>
      </BrowserRouter>
    )
  }
}

export default App;
