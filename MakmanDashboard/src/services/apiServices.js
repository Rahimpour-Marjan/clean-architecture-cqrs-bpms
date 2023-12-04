import { request } from './request';

export class ApiService {
  async get(path, query) {
    const result = await request({
      method: 'GET',
      query,
      path,
    });

    return result.body;
  }

  async getById(id, path) {
    const result = await request({
      method: 'GET',
      path: `/api/${path}/${id}`,
    });
    return result.body;
  }

  async post(path, requestBody) {
    const response = await request({
      method: 'POST',
      path,
      body: requestBody,
    });

    return response?.body;
  }

  async deleteById(requestBody, path) {
    const response = await request({
      method: 'DELETE',
      body: requestBody,
      path: `/api/${path}`,
    });

    return response;
  }

  async put(id, requestBody, path) {
    const response = await request({
      method: 'PUT',
      path: `/api/${path}/${id}`,
      body: requestBody,
    });
    return response.body;
  }
}

export const { get, post, getById, deleteById } = new ApiService();
