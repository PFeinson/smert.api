import React, { Component } from 'react';
import {Route, Routes} from 'react-router-dom'
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
        <Routes>
          <Route path = "/login" element={<LoginPage/>}/>
          <Route path = "/signup" element={<RegistrationPage/>}/>
        </Routes>
       
      </div>
    );
  }
}

export default App;
