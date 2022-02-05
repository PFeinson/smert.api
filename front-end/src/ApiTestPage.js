import React, { Component } from 'react';
import { login } from './services/UserService';

// we test api calls before creating UI here

class apiTestPageComponent extends Component
{
    testLogginHandler = ()=>
    {
        let params = 
        {
            userName: 'mgulenko',
            password: '1234'
        };
        login(params, true);
    }

    testCreateNewUserHandler = ()=>
    {
        window.confirm("Testing new user");
    }

    render()
    {
        return(
            <div>
                <h1>API Test Page</h1>
                <div>
                    <button onClick = {this.testLogginHandler}>Loggin</button>
                    <button onClick = {this.testCreateNewUserHandler}>Create New Uer</button>
                </div>
                <div>Result:</div>
            </div>
        );
    }
}

export default apiTestPageComponent;