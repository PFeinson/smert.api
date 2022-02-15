import React, { Component } from 'react';
import './App.css';
//import ApiTestPage from './ApiTestPage';
import LoginPage from './pages/login/LoginPage'
import RegistrationPage from './pages/registration/RegistrationPage'

class App extends Component 
{
  render() 
  {
    return (
      <div>
          <RegistrationPage/>
      </div>
    );
  }
}

export default App;
