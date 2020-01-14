import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from "react-router-dom";
import './App.css';

import Home from './pages/Home/Home';
class App extends Component {

  render() {
  return (
    <div className="App">
        <Router >
        <Route path={"/"} render={ (props) => <Home  />} />
            {/* <Route path={"/Home"} render={ (props) => <Home user={this.user} />} /> */}
            {/* <Route path={"register"} component={}/> */}
        </Router>
    </div>
  );
  }
}

export default App;
