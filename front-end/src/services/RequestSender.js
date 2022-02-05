/**
 * This file contains wrapper functions around fetch API, 
 * to issue http requests such as GET and POST.
 */


/**
 * 
 * @param {string} url endpoint
 * @param {object} params parameters to be posted with the method
 * @param {string} httpMethod GET or POST
 * @returns reposnse from the server
 */
const request = async (url, params, httpMethod)=>
{
    //if we are sending http get, add params into URL
    if(httpMethod === 'GET')
        url += '?' + (new URLSearchParams(params)).toString();
    //otherwise it is post, and paprms will be added to the body of the method
    else
        params.body = JSON.stringify( params );
    //execute request    
    return await fetch(url, params);
};

/**
 * Get function to issue GET http call
 * @param {string} url endpoint
 * @param {object} params parameters to append to the get method
 * @returns response from the server
 */
export const get = (url, params) => request(url, params, 'GET');
/**
 * Post function to issue POST http call
 * @param {string} url 
 * @param {object} params 
 * @returns response from the server
 */
export const post = (url, params) => request(url, params, 'POST');
