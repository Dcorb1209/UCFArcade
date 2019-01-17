import React, { Component } from 'react';
import NaviBar from './Components/NavBar';
import { Button } from 'react-bootstrap';

class MyProfile extends Component {
  render() {
    return (
      <div className = 'FullPage'>
        <NaviBar/>
        <div>
          <Thumbnail src="/thumbnaildiv.png" alt="242x200">
            <p>
              <Button bsStyle="primary">Change Avatar</Button>
            </p>
          </Thumbnail>
        </div>
      </div>
    )
  }
}

export default App;