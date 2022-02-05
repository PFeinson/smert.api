/**
 * File contains calls to user endpoints 
 */

import { get } from "./RequestSender";

/**
 * Authenticates user.  
 * @param {object} params contais user credentials. Username, email, or phone associated with account for the userName field and password.
 */
export async function login(params, test = false)
{
    //setup URL and params
    let url = test ? 'https://localhost:5001' : 'production server';
    url += '/Login';

    //TODO: change get to post once endpoint is rewritten 
    const response = await get(url, params);
    const data = await response.json();
    console.log(data);
    return data;
}

/**
 * Creates new user with specified parameters. 
 * @param {object} data 
 */
export async function createUser(data, test = false)
{
    //TODO: change get to post once endpoint is rewritten 
}