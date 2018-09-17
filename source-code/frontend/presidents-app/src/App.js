import React, { Component } from 'react';
import Presidents from './components/Presidents';
import logo from './logo.svg';
import logoPresident from './logo-president.jpg';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="container">
        <div className="card">
          <div className="row">
            <div className="col-sm-2">
              <img src={logoPresident} width="100px" height="100px" /></div>
            <div className="col-sm-10">
              <h1 className="display-4">Presidents Of America</h1></div>
          </div>
          <hr className="my-4" />
          <p className="lead">Corcoran technical test</p>
        </div>
        <Presidents />
      </div>
    );
  }
}

export default App;
