/**
 * File contains calls to user endpoints 
 */

import { devServer, get, productionServer } from "./RequestSender";

/**
 * Authenticates user.  
 * @param {object} params contais user credentials. Username, email, or phone associated with account for the userName field and password.
 */
export async function login(params, test = false)
{
    //setup URL and params
    let url = test ? devServer : productionServer;
    url += '/Login';
    console.log(url);
    //TODO: change get to post once endpoint is rewritten 
    const response = await get(url, params);
    const data = await response.json();
    return data;
}

/**
 * Creates new user with specified parameters. 
 * @param {object} params 
 */
export async function createUser(params, test = false)
{
    //setup URL and params
    let url = test ? devServer : productionServer;
    url += '/Registration';
     //TODO: change get to post once endpoint is rewritten 
     const response = await get(url, params);
     const data = await response.json();
     return data;
}