import { BASE_URL } from '../constants/baseUrl';

export const request = async options => {
  try {
    const headers = new Headers();

    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
    headers.append('Access-Control-Allow-Origin', 'same-origin');

    const theRequest = {
      method: options.method,
      headers,
      body: JSON.stringify(options.body),
    };

    const response = await fetch(`${BASE_URL}/api/${options.path}`, theRequest);

    // return result;
  } catch (error) {
    throw new Error('error');
  }
};
