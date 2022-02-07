import React, { Component } from 'react';
import { login, createUser } from './services/UserService';

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
        let params = 
        {
            userName:     'Frodo',
            emailAddress: 'frodo@somewhere.com',
            password:     '1234'
        };
        createUser(params, true);
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